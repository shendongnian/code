    DataTable ref1 = ConvertCSVtoDataTable(csv, firstRowsToDelete: 15); // Return's a Datatable from a CSV
    
    List<Entity> list = new List<Entity>();
    
    foreach(string file in ListOfFilesToProcess)
    {
        DataTable tbl = loadExcelFiles(file);
    
        foreach(DataRow dr in tbl.Rows)
        {
             Entity newEntity = new Entity();
             Entity.property1 = dr["Property1"].ToString();
             ... // Keep mapping properties to elements in the datatable
             Entity.Child.Add(new ChildEntity() { prop1 = ref1["ChildProp1"].ToString() });
    
    		list.Add(newEntity);
        }
    }
    
    // Add all newly created entities to the context
    db.Entity.AddRange(list);
    
    // Save the context
    db.SaveChanges();
