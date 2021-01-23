            private void RegexCla(string value, string pattern, string data)
        {
            if(Regex.IsMatch(value, pattern) == true)
            {
                rtb1.Find(data);
                rtb1.SelectionColor = Color.Green;
                rtb1.SelectedText = value;
            }
            else
            {
                rtb1.Find(data);
                rtb1.SelectionColor = Color.Red;
            }
        }
