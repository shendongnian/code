    string query_orig = rtxtQuery.Text;
    query_orig = query_orig.Replace("oscar", "OSCAR");
    query_orig = query_orig.Replace("marta", "MARTA");
    query_orig = query_orig.Replace("ricardo ", "RICARDO ");
     rtxtQryLinea.Text = query_orig;
    
    rtxtQryLinea.Select(query_orig.IndexOf("OSCAR"), "OSCAR".Length);
    rtxtQryLinea.SelectionColor = Color.Aqua;
    
    rtxtQryLinea.Select(query_orig.IndexOf("MARTA"), "MARTA".Length);
    rtxtQryLinea.SelectionColor = Color.Coral;
    
    rtxtQryLinea.Select(query_orig.IndexOf("RICARDO"), "RICARDO".Length);
    rtxtQryLinea.SelectionColor = Color.OrangeRed;
