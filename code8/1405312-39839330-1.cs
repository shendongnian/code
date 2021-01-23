    /* 
     * Built for .NET Core 1.0 on Windows 10 with Portable.BouncyCastle v1.8.1.1
     * 
     * Tested on Chrome v53.0.2785.113 m (64-bit) and Firefox 48.0.2
     * 
     * Massive thanks to Peter Beverloo for the following:
     * https://docs.google.com/document/d/1_kWRLJHRYN0KH73WipFyfIXI1UzZ5IyOYSs-y_mLxEE/
     * https://tests.peter.sh/push-encryption-verifier/
     * 
     * Some more useful links:
     * https://developers.google.com/web/updates/2016/03/web-push-encryption?hl=en
     * https://github.com/web-push-libs/web-push/blob/master/src/index.js
     * 
     * Copyright (C) 2016 BravoTango86
     *
     * Licensed under the Apache License, Version 2.0 (the "License");
     * you may not use this file except in compliance with the License.
     * You may obtain a copy of the License at
     *
     *      http://www.apache.org/licenses/LICENSE-2.0
     *
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     */
    
    using Microsoft.AspNetCore.WebUtilities;
    using Org.BouncyCastle.Asn1.X9;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Agreement;
    using Org.BouncyCastle.Crypto.Generators;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Security;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    
    public class WebPushHelper {
    
        private const string FirebaseServerKey = "";
    
        public static bool SendNotification(JsonSubscription sub, byte[] data, int ttl = 0, ushort padding = 0,
                                            bool randomisePadding = false) {
            return SendNotification(endpoint: sub.endpoint,
                                    data: data,
                                    userKey: WebEncoders.Base64UrlDecode(sub.keys["p256dh"]),
                                    userSecret: WebEncoders.Base64UrlDecode(sub.keys["auth"]),
                                    ttl: ttl,
                                    padding: padding,
                                    randomisePadding: randomisePadding);
        }
    
        public static bool SendNotification(string endpoint, string data, string userKey, string userSecret,
                                            int ttl = 0, ushort padding = 0, bool randomisePadding = false) {
            return SendNotification(endpoint: endpoint,
                                    data: Encoding.UTF8.GetBytes(data),
                                    userKey: WebEncoders.Base64UrlDecode(userKey),
                                    userSecret: WebEncoders.Base64UrlDecode(userSecret),
                                    ttl: ttl,
                                    padding: padding,
                                    randomisePadding: randomisePadding);
        }
    
        public static bool SendNotification(string endpoint, byte[] userKey, byte[] userSecret, byte[] data = null,
                                        int ttl = 0, ushort padding = 0, bool randomisePadding = false) {
            HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            if (endpoint.StartsWith("https://android.googleapis.com/gcm/send/"))
                Request.Headers.TryAddWithoutValidation("Authorization", "key=" + FirebaseServerKey);
            Request.Headers.Add("TTL", ttl.ToString());
            if (data != null && userKey != null && userSecret != null) {
                EncryptionResult Package = EncryptMessage(userKey, userSecret, data, padding, randomisePadding);
                Request.Content = new ByteArrayContent(Package.Payload);
                Request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                Request.Content.Headers.ContentLength = Package.Payload.Length;
                Request.Content.Headers.ContentEncoding.Add("aesgcm");
                Request.Headers.Add("Crypto-Key", "keyid=p256dh;dh=" + WebEncoders.Base64UrlEncode(Package.PublicKey));
                Request.Headers.Add("Encryption", "keyid=p256dh;salt=" + WebEncoders.Base64UrlEncode(Package.Salt));
            }
            using (HttpClient HC = new HttpClient()) {
                return HC.SendAsync(Request).Result.StatusCode == HttpStatusCode.Created;
            }
        }
    
        public static EncryptionResult EncryptMessage(byte[] userKey, byte[] userSecret, byte[] data,
                                                      ushort padding = 0, bool randomisePadding = false) {
            SecureRandom Random = new SecureRandom();
            byte[] Salt = new byte[16];
            Random.NextBytes(Salt);
            X9ECParameters Curve = ECNamedCurveTable.GetByName("prime256v1");
            ECDomainParameters Spec = new ECDomainParameters(Curve.Curve, Curve.G, Curve.N, Curve.H, Curve.GetSeed());
            ECKeyPairGenerator Generator = new ECKeyPairGenerator();
            Generator.Init(new ECKeyGenerationParameters(Spec, new SecureRandom()));
            AsymmetricCipherKeyPair KeyPair = Generator.GenerateKeyPair();
            ECDHBasicAgreement AgreementGenerator = new ECDHBasicAgreement();
            AgreementGenerator.Init(KeyPair.Private);
            BigInteger IKM = AgreementGenerator.CalculateAgreement(new ECPublicKeyParameters(Spec.Curve.DecodePoint(userKey), Spec));
            byte[] PRK = GenerateHKDF(userSecret, IKM.ToByteArrayUnsigned(), Encoding.UTF8.GetBytes("Content-Encoding: auth\0"), 32);
            byte[] PublicKey = ((ECPublicKeyParameters)KeyPair.Public).Q.GetEncoded(false);
            byte[] CEK = GenerateHKDF(Salt, PRK, CreateInfoChunk("aesgcm", userKey, PublicKey), 16);
            byte[] Nonce = GenerateHKDF(Salt, PRK, CreateInfoChunk("nonce", userKey, PublicKey), 12);
            if (randomisePadding && padding > 0) padding = Convert.ToUInt16(Math.Abs(Random.NextInt()) % (padding + 1));
            byte[] Input = new byte[padding + 2 + data.Length];
            Buffer.BlockCopy(ConvertInt(padding), 0, Input, 0, 2);
            Buffer.BlockCopy(data, 0, Input, padding + 2, data.Length);
            IBufferedCipher Cipher = CipherUtilities.GetCipher("AES/GCM/NoPadding");
            Cipher.Init(true, new AeadParameters(new KeyParameter(CEK), 128, Nonce));
            byte[] Message = new byte[Cipher.GetOutputSize(Input.Length)];
            Cipher.DoFinal(Input, 0, Input.Length, Message, 0);
            return new EncryptionResult() { Salt = Salt, Payload = Message, PublicKey = PublicKey };
        }
    
        public class EncryptionResult {
            public byte[] PublicKey { get; set; }
            public byte[] Payload { get; set; }
            public byte[] Salt { get; set; }
        }
    
        public class JsonSubscription {
            public string endpoint { get; set; }
            public Dictionary<string, string> keys { get; set; }
        }
    
        public static byte[] ConvertInt(int number) {
            byte[] Output = BitConverter.GetBytes(Convert.ToUInt16(number));
            if (BitConverter.IsLittleEndian) Array.Reverse(Output);
            return Output;
        }
    
        public static byte[] CreateInfoChunk(string type, byte[] recipientPublicKey, byte[] senderPublicKey) {
            List<byte> Output = new List<byte>();
            Output.AddRange(Encoding.UTF8.GetBytes($"Content-Encoding: {type}\0P-256\0"));
            Output.AddRange(ConvertInt(recipientPublicKey.Length));
            Output.AddRange(recipientPublicKey);
            Output.AddRange(ConvertInt(senderPublicKey.Length));
            Output.AddRange(senderPublicKey);
            return Output.ToArray();
        }
    
        public static byte[] GenerateHKDF(byte[] salt, byte[] ikm, byte[] info, int len) {
            IMac PRKGen = MacUtilities.GetMac("HmacSHA256");
            PRKGen.Init(new KeyParameter(MacUtilities.CalculateMac("HmacSHA256", new KeyParameter(salt), ikm)));
            PRKGen.BlockUpdate(info, 0, info.Length);
            PRKGen.Update((byte)1);
            byte[] Result = MacUtilities.DoFinal(PRKGen);
            if (Result.Length > len) Array.Resize(ref Result, len);
            return Result;
        }
    
    }
