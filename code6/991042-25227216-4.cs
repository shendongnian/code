      string s = @" Acer P166HQL LED Monitor, 97, 2999 ASRock Penryn 1600SLi, 42, 4688 Gateway KX1563 LED Monitor, 66, 2988";
                string[] splitedText = s.Split(' ');
                StringBuilder sr = new StringBuilder();
                int countOfCommas = 0;
                bool needComma = false;
                foreach (string item in splitedText)
                {
                    if (needComma)
                    {
                        needComma = false;
                        sr.Append(item).Append(',').Append(' ');
                    }
                    else if (item.Contains(","))
                    {
                        if (countOfCommas == 1)
                        {
                            countOfCommas = 0;
                            needComma = true;
                        }
                        else
                        {
                            countOfCommas++;
                        }
                        sr.Append(item).Append(' ');
                    }
                    else
                    {
                        sr.Append(item).Append(' ');
                    }
                }
    
                string str = sr.ToString();
                string[] splitedTextByComma = str.Split(',');
                int j = 0;
                for (int i = 0; i < splitedTextByComma.Length; i++)
                {
                    switch (j)
                    {
                        case 0:
                            j++;
                            string NAME = splitedTextByComma[i];
                            break;
                        case 1:
                            j++;
                            int QUANTITY = int.Parse(splitedTextByComma[i]);
                            break;
                        case 2:
                            j = 0;
                            int UNITPRICE = int.Parse(splitedTextByComma[i]);
                            break;
                    }
                }
            }
