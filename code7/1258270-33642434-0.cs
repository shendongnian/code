    // ...
    if(dt.Rows.Count == 1)
    {
        switch (dt.Rows[0]["Role"] as string)
        {
            case "Admin":
            {
                this.Hide();
                AdminMenu ss = new AdminMenu();
                ss.Show();
                break;
            }
    
            case "Client":
            {
                this.Hide();
                MenuForm mf = new MenuForm();
                mf.Show();
                break;
            }
    
            default:
            {
                // ... handle unexpected roles here...
                break;
            }
        }
    }
