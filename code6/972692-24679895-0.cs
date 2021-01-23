    String whereclause = String.Join(",", wheres.Select(w => "'"+w+"'").ToArray());
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Data Source=XXXXXX; Initial Catalog=XXXXX; Integrated Security=True";
        conn.Open();
        SqlCommand cmd = new SqlCommand("select item_ID from items where item_name in (" + whereclause + ")", conn);
