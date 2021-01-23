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
                    textBox[i].Text = reader.GetValue(0);  -- Text is the Textbox property.
                    this.Controls.Add(textBox[i]);     -- You add the control object
                    i++;
                }
