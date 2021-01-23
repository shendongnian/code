       public async Task<ActionResult> IncrementRefreshcounter(int id)
       {
         using ( var context = new MyDBContext())
         {
    //at each page refresh i would be passing different id to my controller from view.for eg 1,2,3,4
         var data=context.Statistics.where(x=>x.Depth==1 && r.Id==id).FirstorDefualt();
             context.RefreshCounter++;//Increment here RefreshCounter.
             await context.SaveChangesAsync();
            }
        }
