    List<string> list = new List<string>();
                list.Add("Ş\nŞ");
                list.Add("*Ş\nŞ");
                list.Add("Ş\nŞ");
                list.Add("*Ş\nŞ");
    
                for (int s = 0; s < list.Count; s++)
                {
                    var txtLength = richTextBox1.Text.Length;
                    if (list.ElementAt(s)[0] == '*')
                    {
                        var myString = list.ElementAt(s).Substring(1, list.ElementAt(s).Length - 1);
                        richTextBox1.AppendText(myString);
                        richTextBox1.SelectionStart = txtLength;
                        richTextBox1.SelectionLength = myString.Length;
                        richTextBox1.SelectionColor = Color.Red;
                        
                        if (s != list.Count - 1) richTextBox1.AppendText("\r\n\r\n");
                    }
                    else
                    {
                        var myString = list.ElementAt(s);
                        richTextBox1.AppendText(myString);
                        richTextBox1.SelectionStart = txtLength;
                        richTextBox1.SelectionLength = myString.Length;
                        richTextBox1.SelectionColor = Color.Black;
                        if (s != list.Count - 1) richTextBox1.AppendText("\r\n\r\n");
                    }
                }
    
                richTextBox1.Select(0,0);
