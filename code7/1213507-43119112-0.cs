    public void Merge(MyDataBaseEntity[] array)
    {
         using (var ctx = new Entities())
         {
             var list = array.ToList();
             ctx.BulkMerge(list);
         }
    }
