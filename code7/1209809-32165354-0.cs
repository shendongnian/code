            string input;
            string encrypt = ""; string decrypt = "";
            int charCount = 0;
            input = "textBox.Text";
            foreach (char c in input)
            {
                int x = (int)c;
                string s = x.ToString("000");
                encrypt += s;
                charCount++;
            }
            // MessageBox.Show(encrypt);
            while (encrypt.Length > 0)
            {
                int item = Int32.Parse(encrypt.Substring(0, 3));
                encrypt = encrypt.Substring(3);
                char c = (char)item;
                string s = c.ToString();
                decrypt += c;
            }
