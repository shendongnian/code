               string hex = "0123456789ABCDEF";
                string a = "1AD9B1E7D11FEA4FC89493E1";
                byte[] bytes = a.Select(x => (byte)hex.IndexOf(x)).ToArray();
                List<UInt16> results = new List<ushort>();
                for (int i = 0; i < bytes.Count(); i += 4)
                {
                    results.Add(BitConverter.ToUInt16(bytes, i));
                }​
