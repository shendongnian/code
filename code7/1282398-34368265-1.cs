     for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        string str = (string)checkedListBox1.Items[i];
                        textBox1.Text += str;
                    }
                }
