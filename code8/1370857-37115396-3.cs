    public DataSet FilterKategori()
    {
    
    string Data = @"SELECT [DataID], [MærkeID], [Billed], [Model], [Årgang], [Motor Type], [Krydsmål], [Centerhul],
        [ET], [Møtrikker], [Bolter], [Dæk], [Fælge]
    FROM 
        [OminiData].[Data].[Hjuldata]
    WHERE
        Krydsmål = @param1";
    
    //SQL statement to fetch entries from products
    DataSet dsdata = new DataSet();
    
    //Open SQL Connection
    using (SqlConnection conns = new SqlConnection(connStrings))
    {
    conns.Open();
    
    //Initialize command object
    using (SqlCommand cmds = new SqlCommand(Data, conns))
    {
       cmds.Parameters.AddWithValue("@param1", SelectedParam );
       SqlDataAdapter adapters = new SqlDataAdapter(cmds);
       //Fill the result set
      adapters.Fill(dsdata);
    }
    
    }    
    return dsdata;
    }
