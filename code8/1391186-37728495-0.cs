    public void VerifierVersionDejaPresnte(ParseurXML.DonneesGlobales donneGlobale)
    {
    OracleCommand cmd = new OracleCommand();
    cmd.Connection = conn;
    cmd.CommandText = "select nom_projet from analyses where nom_projet=:?";
    cmd.Parameters.Add(new OracleParameter("test", "demonstration"));
    cmd.CommandType = CommandType.Text;
    OracleDataReader dr = cmd.ExecuteReader();
    if (dr.Read())
        Console.WriteLine("Data already exist");
    else
        Console.WriteLine("Data doesn't exist");
    }
