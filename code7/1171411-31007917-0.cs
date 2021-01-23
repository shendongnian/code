    class Data<T>()
    {
      public int Id {get; set;}
      public T Value{get; set;}
    }
    var cols=dtChild.Columns.OfType<DataColumn>().All(c=>c.Name).toList();
    var idCol=cols.Single(c=>c=="Id");
    var valcols=cols.Where(c=>c!="Id");
    var lst=new List<Data>();
    var chlds=dtChild.Rows.OfType(DataRow);
    chlds.ToList().ForEach(c=>lst.Add(new Data{ Id=c[idCol], Value=null} ); //initialize to null
    foreach(var r1 in chlds)
    {
      foreach(var r2 in dtMaster.Rows.OfType(DataRow))
      {
        if (r1[idcol]==r2[idCol])
        {
           forech(var c in valCols)
           {
            if (r1[c]==r2[c])
            {
              lst.Single(l=>l.Id==r1[c]).Value= r2[idCol];
              break;
            }
           }
        }
      }
    }
