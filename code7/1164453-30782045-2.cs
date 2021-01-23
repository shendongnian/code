        public string IntToToHex(string integerAsAString)
        {
            if (!string.IsNullOrEmpty(integerAsAString))
            {
                Int64 integerValue = 0;
                bool parsed = Int64.TryParse(integerAsAString, out integerValue);
                if (parsed)
                    return integerValue.ToString("X");
                else
                    throw new Exception(string.Format("Couldn't parse {0} hex string!", integerAsAString));
            }
            else
                throw new Exception(string.Format("Couldn't parse {0} hex string!", integerAsAString));
        }
