    using System;
    using System.Security.Cryptography;
    using Newtonsoft.Json;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Security;
    
    namespace ConsoleApp1
    {
        class Program
        {
            public static void Main()
            {
                var json = "{\"private_key_id\":\"xxxxxx\",\"private_key\":\"-----BEGIN PRIVATE KEY-----\\nMIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQDcmuyQC8rwWdPQ\\nmIdksgzSJbVWTU5MeUxy+HAap3yut9wR/L6KGMJ4FBYcsPmXN5gQAhErybavGoZG\\nfS1X1/PCpPVpTCA4749K8gbvuZg1JEIAqMtmHiBBrJj5l8eiekQc8pd7Pq35H4wi\\nJYXAJGwggPcttkLBRi0xZzd+jdwL1st+7zRt8nMao/xFibInBBvKwb/gP4mJxlQg\\nnRdGO6zgMk+PLTcA5C+gFyPA4SdkylrLib5CJO9123FgcfTJZJTukeHo1v0EfU+4\\n3bK8HBZnOFa4DHH4mXhkhgYMjibv4Sr/WCEoomJJwNN04SbUEdyhgpM2rZ3cvx+4\\nsmB0SQflAgMBAAECggEAXZ100+/dL7++zh9cHVQdcrRDzprBplw3H/bjg7wdgftN\\n7Wgm5214YQKNG6HSWORjqC9oX/+agZYs8w69xjBDJg9ggU2nwuGOGky4utQ0jiCT\\nzbnTjsMsBxKaXBiXxBBEhVBBDjDcHQLRMdBggNgz9lskCYb1rxT7qqJVf2PtxCuZ\\nuxw3whLMRHXvKosER12sMQgGB/0+Nk86GWCqPigpfu7Ec92V0ffcSUaq3gjIUD54\\n67TduTWaRDQNB+j2yQsWQZnqRv+TvIXOjinAI+pPbvCUovtiTSZAoz3EalsiXQ0l\\nUqDVx26uzEJqhB2kzvAeApuW2Nd5EPxUnf48c4xh4QKBgQDw01mEChWyENV5CBKU\\nMSfY0rpAPtq7ahHRR458ZKtITDBlqiZLMjydI65Rr1XxpQ3pJZALObMdUhbvCDfm\\nu4BY/lCCt+hcdt9IICvVZsgXgvb6M+Fj2IbYZcAnOm4T1Z1D3I+pW5NdK2ALQRiK\\nWsGINOqWCB9WRd7nhmb/XwWyjQKBgQDqgWht5laDuLMc4qpj9finY4qmk57eT3KG\\npzbVlT3h7kv7j/j6e+6o9psrqdf1PXpu9XZi3bPtPbH1fX9x5pZgJQRMP4FGOURY\\nQDkJfiOOSN/8Vl0senqkscT7DSbe2BqyqQlSlTB4BBF29p1wxb5Wz5HH2BvYE2zI\\ni9B4WJcAuQKBgADnajCasRYoBgUcSKWRwaqIr/ZJxhxp+4Mjl59T6WiuEIhxKQ+j\\nMqMMXT0lQVdU3UaAw5enMcrsYfWnvD37ejHbUoYLFq4yLAhjRobYieu8rByoUTJE\\nv8zUJPKAv6UHaj20+D0UgOsanJOuPN9YE93lBPRnN2blgD6yPHS88JKJAoGABFyh\\n16F4LH0L/9aLes6BcIOeeZi3VMU/iRelInXjL8eh7CzyYZ5agxQLMNW46ZvaIiQ4\\nroAXL6t9GubZrwGt/F3T5aMswWShS87uAKoy+RuL5wKoOwKQM24HDvBgr7ZvULFq\\nNfoGa8UPmhneNdHHx4+W05PGeM9rr5NCLmrfbCkCgYA0nMvEDIJvU3KA3S1cQ3fs\\nVopRJwqRIFFL1cHTWaEyIsxEh6i/zAUc/habK82dN3/ZDn/XvWY14k7VZPsSdDC9\\noVlQj2z8DVO2K99Oxyh0VlthtecW8exjzkIPJL4srOSl/dooQZS/7ZZyaRQU/BLI\\nMdzKHlUKKXWcUU+Ko8W4+w==\\n-----END PRIVATE KEY-----\\n\",\"client_email\":\"dddddd-2a1f881e7rabfkt2eb1p84aisg30pedg@developer.gserviceaccount.com\",\"client_id\":\"ddddd-2a1f881e7rabfkt2eb1p84aisg30pedg.apps.googleusercontent.com\",\"type\":\"service_account\"}";
    
                dynamic jsonObject = JsonConvert.DeserializeObject(json);
    
                var rsaParams = ConvertPKCS8ToRSAParameters((string)jsonObject.private_key);
    
                RSACryptoServiceProvider key = new RSACryptoServiceProvider();
                key.ImportParameters(rsaParams);
    
                Console.WriteLine($"Key size: {key.KeySize}, DP: {rsaParams.DP.Length}");
                Console.ReadLine();
            }
    
            private const string PrivateKeyPrefix = "-----BEGIN PRIVATE KEY-----";
            private const string PrivateKeySuffix = "-----END PRIVATE KEY-----";
    
            /// <summary>Converts the PKCS8 private key to RSA parameters. This method uses the Bouncy Castle library.</summary>
            private static RSAParameters ConvertPKCS8ToRSAParameters(string pkcs8PrivateKey)
            {
    
                var base64PrivateKey = pkcs8PrivateKey.Replace(PrivateKeyPrefix, "").Replace("\r\n", "").Replace(PrivateKeySuffix, "");
                var privateKeyBytes = Convert.FromBase64String(base64PrivateKey);
                RsaPrivateCrtKeyParameters crtParameters = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(privateKeyBytes);
    
    
                return DotNetUtilities.ToRSAParameters(crtParameters);
            }
        }
    }
