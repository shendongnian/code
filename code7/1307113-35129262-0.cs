    DropDownListSelectEmployee.Items.Add("nWorks User");
    while (rdr.Read())
                    {
                        user = rdr.GetString("username");
                        DropDownListSelectEmployee.Items.Add(user);
                    }
