                string hex = "0123456789ABCDEF";
                string a = "1AD9B1E7D11FEA4FC89493E1";
                int[] nibbles = a.Select(x => hex.IndexOf(x)).ToArray();
                List<UInt16> results = new List<ushort>();
                for (int i = 0; i < nibbles.Count(); i += 4)
                {
                    results.Add((ushort)((nibbles[i] << 12) | (nibbles[i + 1] << 8) | (nibbles[i + 2] << 4) | nibbles[i + 3]) );
                }​
                string[] test = results.Select(x => x.ToString("X4")).ToArray();​
