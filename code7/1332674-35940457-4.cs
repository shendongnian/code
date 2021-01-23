    con.Open();  -- you need open the connection before the command
    using (var cmd2 = new OdbcCommand("select value,entity_id,store_id 
                                       from catalog_category_entity_varchar 
                                       where attribute_id = 41 ", con))
    {
            using (var reader = cmd2.ExecuteReader())
            {
                int i = 0;
                while (reader.Read())
                {
                    TextBox txt = new TextBox();
                    txt.Text =  reader.GetString(0);
                    txt.Location.x = 100;
                    txt.Location.y = 100 * i;
                    this.Controls.Add(txt);
                    i++;
                }
