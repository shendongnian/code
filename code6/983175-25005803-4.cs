    ....
    var columnValues = new List<string>();
    foreach (XElement xele in rootele)
    {
    	GridViewColumn gvc = new GridViewColumn();
    	gvc.DisplayMemberBinding = new Binding(String.Format("[{0}]", counter)); 
    	gvc.Header = xele.Name.LocalName; 
    	gv1.Columns.Add(gvc); 
    	columnValues.Add((string)xele);
    	counter++;
    }
    lv1.Items.Add(columnValues);
    ....
