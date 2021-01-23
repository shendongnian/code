     protected void LoadOptions()
        {
            DataTable CardCode = new DataTable();
            SqlConnection connection = new SqlConnection("my connection string");
            using (connection)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT CardCode,CardName, Address, CntctPrsn FROM OCRD", connection);
                adapter.Fill(CardCode);
                if (CardCode.Rows.Count > 0)
                {
                    for (int i = 0; i < CardCode.Rows.Count; i++)
                    {
                         id = CardCode.Rows[i]["CardCode"].ToString();
                         name = CardCode.Rows[i]["CardName"].ToString();
                         newName = id + " ---- " + name;
                         DropDownList1.Items.Add(new ListItem(newName,id));
                    }
                }
            }
        }
