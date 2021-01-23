    using(dbContext context = new dbContext())
    {
       foreach(var ID in ListOfIdThatNeedToBeRemoved)
       {
          context.tbl_persons.RemoveRange(context.tbl_persons.Where(x => x.id == ID));
          context.SaveChanges();
       }
    }
