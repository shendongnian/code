            StreamWriter OutFile = new StreamWriter("MyFile.txt", false);
            int i = 0;
            foreach (object M in comboBox1.Items)
            {
                List<string> mystrings = new List<string>();
                mystrings.Add(comboBox1.Items[i].ToString());
                mystrings.Add(comboBox2.Items[i].ToString());
                
                OutFile.WriteLine(String.Join(",", mystrings));
                i++;
            }
            OutFile.Close();
