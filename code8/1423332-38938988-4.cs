    [TestClass]
    public class JwtUnitTest {
        [TestMethod]
        public void VerifySignature() {
            string jwt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWV9.TJVA95OrM7E2cBab30RMHrHDcEfxjoYZgeFONFh7HgQ";
            string[] parts = jwt.Split(".".ToCharArray());
            var header = parts[0];
            var payload = parts[1];
            var signature = parts[2];//Base64UrlEncoded signature from the token
            byte[] bytesToSign = getBytes(string.Join(".", header, payload));
            byte[] secret = getBytes("secret");
            var alg = new HMACSHA256(secret);
            var hash = alg.ComputeHash(bytesToSign);
            var computedSignature = Base64UrlEncode(hash);
            Assert.AreEqual(signature, computedSignature);
        }
        private static byte[] getBytes(string value) {
            return Encoding.UTF8.GetBytes(value);
        }
        // from JWT spec
        private static string Base64UrlEncode(byte[] input) {
            var output = Convert.ToBase64String(input);
            output = output.Split('=')[0]; // Remove any trailing '='s
            output = output.Replace('+', '-'); // 62nd char of encoding
            output = output.Replace('/', '_'); // 63rd char of encoding
            return output;
        }
    }
