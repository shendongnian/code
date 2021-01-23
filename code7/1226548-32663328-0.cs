    private void button1_Click(object sender, EventArgs e)
        {            
            using (StreamReader sr = new StreamReader("C:/ctb.txt"))
            {
                String line = sr.ReadToEnd();
                foreach (Match m in Regex.Matches(line, "\\[(str)\\]\\ = \"\\w+\\, +\\w+\""))
                {
                    string name = m.Value.Replace("[str] = \"", "");
                    name = name.Replace("\"", "");
                    textBox1.Text = name;
                }
                
            }
            using (StreamReader sr2 = new StreamReader("C:/contacttoolbar.txt"))
            {
                String line = sr2.ReadToEnd();
                foreach (Match m2 in Regex.Matches(line, "\\[(str)\\]\\ = \"\\d\\s\\d{3}\\s\\d{3}-\\d{4}\""))
                {
                    string tele = m2.Value.Replace("[str] = \"", "");
                    tele = tele.Replace("\"", "");
                    textBox2.Text = tele;
                }
            }
        }
