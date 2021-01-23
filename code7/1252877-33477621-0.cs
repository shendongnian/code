    foreach (var property in typeof(DiagTab).GetProperties())
    {    
        string name = property.Name;
        if (name == "ID_Diag") { continue; } // no column 1 and 2 
        if (name == "Reponse") { continue; } 
    
        // selector = (DiagTab source) => (int)source.Property
        var source = Expression.Parameter(typeof(DiagTab), "source");
        var selector = Expression.Lambda<Func<DiagTab, int>>(
            Expression.Convert(Expression.Property(source, property), typeof(int)),
            source);
    
       int sum = db.DiagTabs.Sum(selector);
       dictionary.Add(name, sum);                      
    }
