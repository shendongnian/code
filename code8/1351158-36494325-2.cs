    var toExclude = new HashSet<string>
    {
        "ID",
        "SubSystemID",
        "System",
        "Component",
        "ReferenceNumber",
        "IsValid"
    };
    
    var propsIndividuals = typeof(Person).GetProperties(BindingFlags.Public | BindingFlags.Instance).
                           Where(property => !toExclude.Contains(property.Name));
    
    var rowHeader = new new HtmlTableRow("th")
    
    foreach (var property in propsIndividuals)
    {
        rowHeader.Cells.Add(new HtmlTableCell { InnerText = property.Name });
    }
    
    tableIndividuals.Rows.Add(rowHeader);
         
