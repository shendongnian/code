               List<string> Values = new List<string>();
                foreach (TextBox txt in this.Controls)
                {
                    if (!string.IsNullOrWhiteSpace(txt.Text))
                    {
                        Values.Add(txt.Text);
                    }
                }
                    or
                int countOfTextBoxes= //Your TextBox Count;
                TextBox txt;
                for (int i = 1; i <= countOfTextBoxes; i++)
                {
                    txt = (TextBox)this.Controls["entry_" + i];
                    if (!(string.IsNullOrWhiteSpace(txt.Text)))
                    {
                        //Your Code For Retreiving Texts
                    }
                }
