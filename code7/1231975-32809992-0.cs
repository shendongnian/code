    class Order
    { 
        public int Id {get; set;}
        public int OrderId {get; set;}
        public int Number {get; set;
    }
    ...
    var oc = (IObjectContextAdapter)db).ObjectContext;
    var orders = oc.Translate<Order>(reader).ToLookup(x => x.Id);
    foreach(var employee in model.Employees)
        employee.Orders = orders[employee.Id].ToList();
