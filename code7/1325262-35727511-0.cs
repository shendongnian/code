    public decimal ReturnAmount(int Id, int Year)
    {
      .... (Some other Logic) ....
      var RouteList = Model.Where(asd => asd.Year == Year).ToList();
      RouteList = GetRoutingList(RouteList, Id);
      .... (Other logic here)....
      var Amount = NewModelList.Sum(asd => asd.Allocated_Cost_to_Dept); // returns decimal
      return Amount;
    }
