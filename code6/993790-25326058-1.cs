    try
            {
                String selectCommand = "Enter selectcommand here";
                String connectionString = "Enter connectionString here";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand, connectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
