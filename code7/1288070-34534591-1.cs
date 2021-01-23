    private void FindGarageID()
    {
        string loginName = Session.UserName;
        using (tyrescannerdatabaseEntities dbcontext = new tyrescannerdatabaseEntities())
        {
            garage = (from r in dbcontext.AspNetUsers
                          where r.UserName == loginName
                          select r).FirstOrDefault();
            if (!garage.GarageID.Equals(null))
            {
                garageID = (int)garage.GarageID;
            }
            else
            {
                garageID = 1;
            }
       }
