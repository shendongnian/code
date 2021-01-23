        private void Findword(string FindText, RichTextBox rt)
        {
            try
            {
                List<int> lst = new List<int>();
                bool IsRun = true;
                int Index = 0;
                int count =0;
                lst.Add(-1);
                lst.Add(0);
                lst.Add(rt.TextLength);
                while (IsRun)
                {
                    Index = rt.Find(FindText, Index, RichTextBoxFinds.WholeWord);
                    if (lst.Contains(Index))
                        break;
                    else
                        count++;
                    lst.Add(Index);
                    Index += FindText.Length;
                }
                MessageBox.Show(FindText + " Count: " + count);
            }
            catch { }
        }
