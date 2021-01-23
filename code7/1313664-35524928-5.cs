    public DataTable GetCustomers(int LocationId, int ActiveId, string stats)
    {
        using (var context = new MyContext())
        {
            var data = from c in context.Customers
                       where c.Removed == false
                       select new
                       {
                           FullName = c.FullName,
                           c.CustomerID,
                           c._Location.Name,
                           c.IsActive,
                           c.SubscribeDate,
                           c.Removed
                       };
            bool LocationIdNotApplied = LocationId == 0; //for comp1
            bool IsActiveNotApplied = LocationId != 0 && (ActiveId < 0 || ActiveId > 2 || stats = "subscribe"); //for comp3 to be applied or not
            bool IsActiveFalse = (LocationId != 0 && ActiveId == 2) || stats == "unsubscribe" || (ActiveId == 2 && stats == "subscribe"); //for comp3 to be false
            bool DateApplied = LocationId == 0 || (LocationId != 0 && stats == "subscribe");
            if(LocationId == 0 && ActiveId == 1 && stats == "all"){ //case 6
                return MyContext.CopyToDataTable(
                         data.Where(x => (x.SubscribeDate >= DateTime.Now.AddDays(-7) || x.IsActive == true) || (x.Removed == false) || (x.SubscribeDate >= DateTime.Now.AddDays(-7) || x.IsActive == false)));          
            } else if (LocationId == 0 && ActiveId == 2 && stats == "all"){ //case 9
                return MyContext.CopyToDataTable(
                         data.Where(x => (x.SubscribeDate >= DateTime.Now.AddDays(-7) || x.IsActive == false) && (x.Removed == false)));
            } else { //other cases
                return MyContext.CopyToDataTable(
                         data.Where(x => (x.LocationId == LocationId || LocationIdNotApplied) //comp1
                           && x.IsRemoved == false //comp2
                           && ((x.IsActive == !IsActiveFalse) || IsActiveNotApplied) //comp3
                           && (x.SubscribeDate >= DateTime.Now.AddDays(-7) || !DateApplied))) //comp4
            }
        }        
    }
