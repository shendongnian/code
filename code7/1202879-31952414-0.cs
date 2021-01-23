    foreach(var name in list)
    {
         if(table.Any(t => SqlMethods.Like(name, string.Format("%{0}%", t.Column))
         { ... 
         }
     }
