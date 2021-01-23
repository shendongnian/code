            void Metodo2()
            {
                var cifrita = new List<string>();
                var numbers = new List<int>(new int[] { 3, 2, 1 });
                var result = new List<int>();
                string cadena = richTextBox1.Text;
                char[] xd = cadena.ToCharArray();//
                int i = 0;
                foreach (char c in xd)
                {
                    result.Add((int)Char.GetNumericValue(c) * numbers[i]);
                    i = (++i) % numbers.Count; // iterating over smaller list
                }
    
                StringBuilder concatenatedString = new StringBuilder();
                foreach (var cifra in result)
                {
                    concatenatedString.Append(cifra).Append(" ");
    
                }
                richTextBox1.Text = concatenatedString.ToString();
            }
