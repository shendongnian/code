     private void textBox1_KeyDown(object sender, KeyEventArgs e)
      {
                if (e.KeyCode == Keys.Enter)
                {
                    string substr;
                    string str = textBox1.Text.ToString();
                    Match m = Regex.Match(str, @"(?<=.\s+).+?(?=\s+from)", RegexOptions.IgnoreCase);
                   try
                   {
                       if (m.Success)
                       {
                           substr = m.Value;
                           string[] sub = substr.Split(',');
                           foreach (string x in sub)
                           {
                               listBox1.Items.Add(x);
                           }
                       }
                   }
                   finally
                   {
                       listBox1.EndUpdate();
                   }
                }
      }
