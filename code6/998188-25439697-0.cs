     string frstvalue = richTextBox1.Text;
            string finalvalue = "";
            char[] a = richTextBox1.Text.ToArray();
            foreach (char c in a)
            {
                if (dictionary.ContainsKey(c))
                { 
                    string value = dictionary[c];
                    finalvalue += value;
                }
            }
            richTextBox2.Text = finalvalue;
