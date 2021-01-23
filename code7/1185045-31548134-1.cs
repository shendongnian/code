            var cspParameters = new CspParameters()
            {
                 KeyContainerName = "MyKeys",
                 Flags = CspProviderFlags.UseMachineKeyStore
            }; //refers to a file in the machine keys directory
            var rsaKey = new RSACryptoServiceProvider(cspParameters);
            var t1 =
                Convert.FromBase64String(
                    "RsMpDD/wJmmpN+Mme+qFuRVm2Ddk759hWM7HaeAnW7xpfkCoC4ko7vDBmqylzQ0QAFL2wuR8u8Bsf+4xwn++Ru/GsEaYrGrcDMYJTuWElyHuxnw+5umqexQJye2R5uL/91alFVNV41HnSPlwuA+pgk14yHSWIflIyKFmUTx58vU=");
            var t2 =
                Convert.FromBase64String(
                    "lQI7gyQZ2HIIQUdKsp73HrYcebbOiO4dCriwCt5avfVTcxPZEHzaCfV52k+triRwq64uGVCNRpGUe5PCVEfbWwrPHaNaFzRp");
            var desKey = rsaKey.Decrypt(t1, false); //get the des key
            var iv = t2.Take(8).ToArray(); //get the initialization vector
            var ct = t2.Skip(8).ToArray(); //get the actual ciphertext
            var desEnc = new TripleDESCryptoServiceProvider()
            {
                Padding = PaddingMode.ISO10126
            };
            var plaintext = Encoding.Default.GetString(desEnc.CreateDecryptor(desKey, iv).TransformFinalBlock(ct, 0, ct.Length));
