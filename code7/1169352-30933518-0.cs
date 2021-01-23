    // the "where 1=1" allows to always concatenate "and xxx".
    var query = "Select * from UniversityData where 1 = 1";
    var parameters = new List<OleDbParameter>();
    
    if (txtDegree.Text != "")
    {
       query += " and Expertise like '%' + @degree + '%' ";
       parameters.Add("degree", txtDegree.Text);
    }
    
    if(txtAgent.Text != "")
    {
        query += " and SourceOfContact like '%' + @agent + '%' ";
        parameters.Add("agent", txtAgent.Text);
    }
    
    OleDbDataAdapter da = new OleDbDataAdapter(query, connection);
    // add the parameters to the adapter (I don't know the syntax)
