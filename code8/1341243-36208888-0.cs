    public void getValue(string tekst)
        {
            char[] trim = { '@', '\t' };
            IList<string> myList = tekst.Split(' ').ToList();
            foreach (string c in myList)
            {
                string d = c.Trim(trim);
                if (d.StartsWith("sub1"))
                {
                    txtT1.Text = d;
                }
                if (d.StartsWith("sub2"))
                {
                    txtT2.Text = d;
                }
            }
        }
