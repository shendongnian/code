     String hs = "x30 30 33 33 20 49 44 5F 30 30 3A 20 20 20 31 30 2E 36 20 6B 67 20 0D 0A 0D 0A";
                System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(hs, "([A-Z-0-9]{2}) ");
                StringBuilder sb = new StringBuilder();
                System.Text.RegularExpressions.Match m = match.NextMatch();
                while(m.Success)
                {
                    var x = Convert.ToUInt32(m.Value.Trim(),16);
                    sb.Append(Convert.ToChar(x));
                   m= m.NextMatch();
                }
    
    
                String s = sb.ToString();
