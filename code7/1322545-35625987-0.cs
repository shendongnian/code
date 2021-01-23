    string ContactPerson = String.Empty;
    string constr = ConfigurationManager.ConnectionStrings["KernelCS"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand(query,con))
        {
            ContactPerson = cmd.ExecuteScalar().ToString();
        }
    }
    return ContactPerson;
