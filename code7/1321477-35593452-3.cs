    private void btnCandy_Click(object sender, EventArgs e)
    {
        string query = "Candy";
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
                    // Escape your plain text before use with regex
                    var pattern = Regex.Escape(query);
                    // Check if s has this formnat: queryx2, queryx3, queryx4, ...
                    Match m = Regex.Match(s, "^" + pattern + @"x(\d+)$");
                    if (m.Success)
                    {
                        lstProducts.Items[i] = query + "x" + (Int32.Parse(m.Groups[1].Value) + 1);
                        isExist = true;
                        break;
                    }
                }
            }
        }
        if (!isExist) lstProducts.Items.Add(query);
    }
