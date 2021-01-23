            string hex = "C26B3CB3833E42D8270DC10C";
            for (int i = 0; i < hex.Length; i++)
            {
                if(i%2==0)
                {
                    sb.Append(",0x").Append(hex.Substring(i, 2));
                }
            }
            Console.WriteLine(sb.ToString());
