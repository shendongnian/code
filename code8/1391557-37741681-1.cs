         if (!string.IsNullOrEmpty(richTextBox1.Text))
                    foreach (string item in richTextBox1.Lines)
                    {
                        List<string> lst = item.Split(new char[] { ';' }).ToList();
                        if (lst.Count == 3)
                        {
                            if (!Regex.IsMatch(lst[1], "^[a-zA-Z]{3}_[0-9]{10}$"))
                            {
                                int Start = richTextBox1.Find(item, RichTextBoxFinds.WholeWord); 
                                int End = Start + item.Length;
                                richTextBox1.Select(Start, End);
                                richTextBox1.SelectionBackColor = Color.Red; 
                            }
                            else
                            {
                                int Start = richTextBox1.Find(item, RichTextBoxFinds.WholeWord); 
                                int End = Start + item.Length;
                                richTextBox1.Select(Start, End);
                                richTextBox1.SelectionBackColor = Color.Green;
                            }
                        }
                    }
