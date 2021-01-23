     String[] s = { "Item Revision", "Integer Item Revision", "Double Item Revision" };
                String[] tmp = new String[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    tmp[i] = s[i].Replace("Revision", "");
                }
