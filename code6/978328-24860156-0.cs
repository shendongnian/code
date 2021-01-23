                string aspxmemo1 = "php;visual basic;c#";
                string aspxmemo2 = "visual basic;javascript";
                string copies ="";
                string[] group1 = aspxmemo1.Split(';');
                string[] group2 = aspxmemo2.Split(';');
                foreach (string x in group1)
                {
                    if (group2.Contains<string>(x))
                    {
                        copies += x + Environment.NewLine;
                    }
                }
                MessageBox.Show(copies);
