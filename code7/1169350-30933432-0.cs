    var sb = new StringBuilder();
    sb.Append("Select * from UniversityData where 1 = 1");
    if(!string.IsNullOrEmpty(cmbDegree.Text.Trim())){
        sb.Append(" and Expertise like '%" + cmbDegree.Text + "%'")
    }
    //...
    var querystring = sb.ToString();
    OleDbDataAdapter da = new OleDbDataAdapter(querystring);
