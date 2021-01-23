    class EmployeeOrder
    { 
        public int Id {get; set;}
        public int OrderId {get; set;}
        public int Number {get; set;
    }
    ...
    var orders = oc.Translate<EmployeeOrder>(reader).ToLookup(x => x.Id);
    employee.Orders = orders[employee.Id].Select(x => new Order
    {
        OrderId = x.OrderId,
        Number = x.Number
    }.ToList();
