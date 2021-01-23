    // the "where 1=1" allows to always concatenate "and xxx".
    var query = "Select * from UniversityData where 1 = 1";
    var parameters = new Dictionary<string, string>();
    
    if (txtDegree.Text != "")
    {
       query += " and Expertise like '%' + ? + '%' ";
       parameters.Add("degree", txtDegree.Text);
    }
    
    if(txtAgent.Text != "")
    {
        query += " and SourceOfContact like '%' + ? + '%' ";
        parameters.Add("agent", txtAgent.Text);
    }
    
    OleDbDataAdapter da = new OleDbDataAdapter(query, connection);
    // add the parameters
    foreach (var p in parameters) {
        da.SelectCommande.Parameters.Add(p.Key, OleDbType.VarChar, p.Value);
    }
