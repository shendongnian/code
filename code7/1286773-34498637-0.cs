            try
            {
                if (startSelection >= 0)
                {
                    startSelection = rtb.Find(word, startSelection, rtb.TextLength, RichTextBoxFinds.None);
                }
                if (startSelection != -1)
                {
                    char[] arr = new char[] { 'ّ', 'َ', 'ً', 'ُ', 'ٌ', 'ِ', 'ٍ', 'ْ' };
                    int index = 0;
                    string CurrentWord = "";
                    char charForTest;
                    try
                    {
                        while (CurrentWord != word)
                        {
                            rtb.Select(startSelection + index, 1);
                            charForTest = Convert.ToChar(rtb.SelectedText);
                            if (arr.Contains(charForTest))
                            {
                                index++;
                            }
                            else
                            {
                                CurrentWord += charForTest.ToString();
                                index++;
                            }
                        }
                        rtb.Select(startSelection, index);
                        rtb.SelectionColor = System.Drawing.Color.Red;
                        startSelection += index;
                        v_srarch_WithOutTashkilAll(word, rtb);
                    }
                    catch (Exception)
                    { }
                }
            }
            catch (Exception)
            { }
        }
