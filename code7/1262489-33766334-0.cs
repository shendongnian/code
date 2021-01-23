    static string GetText(Control c)
    {
        string s = c.Text;
        foreach (Control c2 in c.Controls)
        {
            s += GetText(c2);
        }
        return s;
    }
