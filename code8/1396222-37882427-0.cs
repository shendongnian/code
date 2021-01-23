        private int GetHashCode(IEnumerable<string> value)
        {
            var encoder = new UTF8Encoding();
            var hash = new SHA256CryptoServiceProvider();
            var sb = new StringBuilder();
            foreach (var item in value)
            {
                sb.Append(item);
            }
            return
                Convert.ToInt32(
                    new Rfc2898DeriveBytes(sb.ToString(),
                        hash.ComputeHash(encoder.GetBytes(sb.ToString()))).GetBytes(4));
        }
