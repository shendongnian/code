        private bool CompareLists(IEnumerable<string> value1, IEnumerable<string> value2)
        {
            // First convert lists to single strings
            var encoder = new UTF8Encoding();
            var hash = new SHA256CryptoServiceProvider();
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();
            foreach (var item in value1)
            {
                sb1.Append(item);
            }
            
            foreach (var item in value2)
            {
                sb2.Append(item);
            }
            // Then hash and compare
            return Convert.ToBase64String(hash.ComputeHash(encoder.GetBytes(sb1.ToString()))) ==
                   Convert.ToBase64String(hash.ComputeHash(encoder.GetBytes(sb2.ToString())));
        }
