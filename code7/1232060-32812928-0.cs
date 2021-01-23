    //load and output
        private void mnuLoad_Click_1(object sender, EventArgs e)
        {
            if (fd.ShowDialog() == DialogResult.OK)
            {
                //open file to read
                StreamReader sr = new StreamReader(fd.OpenFile());
            //skip first line;
                sr.ReadLine();
                string s;
            //Remove duplications
                Dictionary<string, int> unique_lines = new Dictionary<string, int>();
                for (int i = 0; 
                    (s = sr.ReadLine()) != null; //read until reach end of file
                    i++)
                    if(!unique_lines.Keys.Contains(s))
                        unique_lines[s] = i;//save order of line
            //Restore order:
                SortedDictionary<int, string> sorted_lines = new SortedDictionary<int, string>();
                foreach (string key in unique_lines.Keys)
                    sorted_lines[unique_lines[key]] = key;
            //Output:
                string output = string.Empty;
                foreach (int key in sorted_lines.Keys)
                    output += sorted_lines[key] + "\n";
                lblOutput.Text = output;
            }
        }
