            if (string.IsNullOrEmpty(transferEncoding)) return messageText;
            if ("quoted-printable".Equals(transferEncoding.ToLower()))
            {
                StringBuilder sb = new StringBuilder();               
                string delimitorRegEx = @"=[\r][\n]";
                string[] parts = Regex.Split(messageText, delimitorRegEx);
                foreach (string part in parts)
                {
                    string subPart = part;
                    Regex occurences = new Regex(@"(=[0-9A-Z][0-9A-Z])+", RegexOptions.Multiline);
                    MatchCollection matches = occurences.Matches(subPart);
                    foreach (Match m in matches)
                    {
                        byte[] bytes = new byte[m.Value.Length / 3];
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            string hex = m.Value.Substring(i * 3 + 1, 2);
                            int iHex = Convert.ToInt32(hex, 16);
                            bytes[i] = Convert.ToByte(iHex);
                        }
                       subPart = occurences.Replace(subPart, enc.GetString(bytes), 1);
                    }
                    sb.Append(subPart);
                }
                return sb.ToString();
            }        
            return messageText;
        }
