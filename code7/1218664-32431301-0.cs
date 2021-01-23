    int i = 0;
         
    foreach (object M in comboBox1.Items)
            {
  
                List<string> mystrings = new List<string>();
                mystrings.Add(comboBox2.Items[i].ToString());
                mystrings.Add(M.ToString());
                OutFile.WriteLine(String.Join(",", mystrings));
                i++;
            }
