    using (SqlConnection cn = new SqlConnection(""))
    using (SqlCommand cm = new SqlCommand())
    {
        .....
    
         using (var dr = cm.ExecuteReader(CommandBehavior.SingleResult))
         {
            while (dr.Read())
            {
                //blah blah blah...
            }
         }
    }
