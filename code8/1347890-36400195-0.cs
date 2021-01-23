    if (List.Contains(value))
    {
        switch (value)
        {
            case "admin": permission = x;
                break;
            case "user": tabControl1.TabPages.Remove(tab_Admin);
                break;
            case "user2": tabControl1.TabPages.Remove(tab_Admin);
                tabControl1.TabPages.Remove(tab_Dates);
                break;
            case "guest": tabControl1.TabPages.Remove(tab_Admin);
                tabControl1.TabPages.Remove(tab_Dates);
                tabControl1.TabPages.Remove(tab_Data);
                break;
        }
    }
