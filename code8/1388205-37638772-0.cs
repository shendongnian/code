         string[] array1 = Directory.GetFiles(img_Source_TxtBox.Text);
     // string[] array1 = new string[] { "a", "d", "e", "c", "f", "i" };
                    Array.Sort(array1); // ascending order
                    foreach (string aa in array1)
                    {
                        MessageBox.Show(aa.ToString());
                    }
                    Array.Reverse(array1); // descending order 
        
                    foreach (string aa in array1)
                    {
                        MessageBox.Show(aa.ToString());
                    }
