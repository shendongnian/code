            foreach (string s in lines)
            {
                if (s.StartsWith("["))
                {
                    char[] MyChar = { ']' };
                    string NewString = s.TrimEnd(MyChar);
                    char[] MyChar2 = { '[' };
                    string NewString2 = NewString.TrimStart(MyChar2);
                    comboBox1.Items.Add(NewString2);
                }
                else if (s.Contains("PhoneNumber"))
                {
                    string ip = comboBox1.Items[comboBox1.Items.Count - 1].ToString() + " : ";
                    var x = s.Split('=');
                    if (x.Length > 1)
                        ip += x[1];
                }
            }
