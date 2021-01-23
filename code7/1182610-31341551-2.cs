    DataTable ppl = new DataTable();
    ppl.Columns.Add("id", typeof(int));
    ppl.Columns.Add("name", typeof(string));
    // table is created, let's add some people
    var bob = ppl.NewRow();
    bob["id"] = 1;
    bob["name"] = "Bob";
    ppl.Rows.Add(bob);
    var jim = ppl.NewRow();
    jim["id"] = 2;
    jim["name"] = "Jim";
    ppl.Rows.Add(jim);
    // that's enough people for now, let's call the stored procedure
    using(var conn = new SqlConnection("YouConnStringHere"))
    {
        using(var cmd = new SqlCommand("SaveNewPeople", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            var tvp = new SqlParameter
            {
              ParameterName = "@pPeople",
              SqlDbType = SqlDbType.Structured,
              Value = ppl,
              TypeName = "udt_person"
            }
            cmd.Parameters.Add(tvp);
            conn.Open();
            conn.ExecuteNonQuery();
        }
    }
