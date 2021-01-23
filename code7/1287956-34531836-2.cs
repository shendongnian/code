    foreach (var tableBData in context.TableB.ToList())
    {
        if (tableB.TableA == null)
        {
            var tableA = new TableA();
            tableB.TableB = tableA;
        }
    
        context.SaveChanges();
    }
