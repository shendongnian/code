    [TestClass]
    public class JwtUnitTest {
        [TestMethod]
        public void VerifySignature() {
            string jwt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWV9.TJVA95OrM7E2cBab30RMHrHDcEfxjoYZgeFONFh7HgQ";
            string[] parts = jwt.Split(".".ToCharArray());
            string header = parts[0];
            string payload = parts[1];
            byte[] crypto = Base64UrlDecode(parts[2]); //signature from jwt to be verified
            string headerDotPayload = string.Format("{0}.{1}", header, payload);
            byte[] bytesToSign = System.Text.UTF8Encoding.UTF8.GetBytes(headerDotPayload);
            byte[] secret = System.Text.UTF8Encoding.UTF8.GetBytes("secret");
            var alg = new HMACSHA256(secret);
            var signature = alg.ComputeHash(bytesToSign);
            //doing this just to be able to compare the resulting strings
            var decodedCrypto = Convert.ToBase64String(crypto);
            var decodedSignature = Convert.ToBase64String(signature);
            Assert.AreEqual(decodedCrypto, decodedSignature);
        }
        // from JWT spec
        private static byte[] Base64UrlDecode(string input) {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4) { // Pad with trailing '='s
                case 0: break; // No pad chars in this case
                case 2: output += "=="; break; // Two pad chars
                case 3: output += "="; break;  // One pad char
                default: throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Unable to decode: '{0}' as Base64url encoded string.", input));
            }
            var converted = Convert.FromBase64String(output); // Standard base64 decoder
            return converted;
        }
    }
