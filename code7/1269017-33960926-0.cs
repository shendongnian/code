    foreach (string str in Directory.GetFiles(@"D:\")) 
                {
                    if (System.IO.Path.GetExtension(str).Contains("txt"))
                    {
                        this.Combobox_1.Items.Add(System.IO.Path.GetFileNameWithoutExtension(str));
                    }
                }
