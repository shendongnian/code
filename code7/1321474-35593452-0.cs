    private void btnCandy_Click(object sender, EventArgs e)
    {
        string query = "Candy";
        var pattern = Regex.Escape(query);
        bool isExist = false;
        for (int i = 0; i < lstProducts.Items.Count; i++)
        {
            var s = lstProducts.Items[i].ToString();
            if (s.StartsWith(query))
            {
                if (s == query)
                {
                    lstProducts.Items[i] = query + "x2";
                    isExist = true;
                    break;
                }
                else
                {
                    Match m = Regex.Match(s, "^" + pattern + @"x(\d+)$");
                    if (m.Success)
                    {
                        lstProducts.Items[i] = query + Int32.Parse(m.Groups[1].Value) + 1;
                        isExist = true;
                        break;
                    }
                }
            }
        }
        if (!isExist) lstProducts.Items.Add(query);
    }
