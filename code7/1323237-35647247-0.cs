    public List<MyDto> GetDetails(....
    {
        var result = (from c in ctx.Table1
                      join p in ctx.Table2 on c.ClientId equals p.ClientId
                      select new MyDto
                      {
                         ClientId = c.ClientId,
                         Field2 = p.SomeField 
                      }
    
        return result.ToList();
    }
