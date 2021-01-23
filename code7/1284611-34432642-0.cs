            string str = txtCompanyname.Text.Trim();
            string[] output = str.Split(' ');
            foreach (string s in output)
            {
              
                Response.Write(s);
                string newid += s;
            }
