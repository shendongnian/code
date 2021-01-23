        foreach (String file in allFIles)
        {
            string text = "";
            using (StreamReader r = new StreamReader(file))
            {
                text = r.ReadToEnd();
            }
            
            int x = text.IndexOf(Case1);
            while(x > -1)
            {
                if (text.Length - x > Case1.Length)
                {
                    string nextBit = text.SubString(x + Case1.Length, 1);
                    if (IsDelimeter(nextBit))
                    {
                        text = Replace(text, x, Case1, Case1Const);
                        x += Case1Const.Length;
                    }
                }
                else
                {
                     text = Replace(text, x, Case1 Case1Const);
                     break;
                }
                x = text.IndexOf(Case1, x + 1);
            }
            File.WriteAllText(file, text);
        }
