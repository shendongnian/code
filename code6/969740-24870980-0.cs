     public class OrderViewModel : IEntityViewModel, IDataErrorInfo
            {
                public event PropertyChangedEventHandler PropertyChanged;
    
                internal Order _order;
                INorthwindDbContext _ctx;
    
                public int OrderId
                {
                    get { return _order.OrderId; }
                }
                public DateTime? OrderDate
                {
                    get { return _order.OrderDate; }
                    set
                    {
                        _order.OrderDate = value;
                        RaisePropertyChanged("OrderDate");
                    }
                }
                public string ShipName
                {
                    get { return _order.ShipName; }
                    set
                    {
                        _order.ShipName = value;
                        RaisePropertyChanged("ShipName");
                    }
                }
                public string ShipAddress
                {
                    get { return _order.ShipAddress; }
                    set
                    {
                        _order.ShipAddress = value;
                        RaisePropertyChanged("ShipAddress");
                    }
                }
                public string ShipCity
                {
                    get
                    {
                        return _order.ShipCity;
                    }
                    set
                    {
                        _order.ShipCity = value;
                        RaisePropertyChanged("ShipCity");
                        ;
                    }
                }
    
                public string CustomerId
                {
                    get { return _order.CustomerId; }
                    set
                    {
                        _order.CustomerId = value;
                        var customer = this._ctx.Customers.Find(_order.CustomerId);
                        _order.Customer = customer;
                        RaisePropertyChanged("CustomerId");
                        RaisePropertyChanged("CompanyName");
                        RaisePropertyChanged("ContactName");
                    }
                }
                public string CompanyName
                {
                    get { return _order.Customer != null? _order.Customer.CompanyName : string.Empty; }
                }
                public string ContactName
                {
                    get { return _order.Customer != null ? _order.Customer.ContactName : string.Empty; }
                }
    
                public int? EmployeeId
                {
                    get { return _order.EmployeeId; }
                    set
                    {
                        _order.EmployeeId = value;
                        var employee = this._ctx.Employees.Find(_order.EmployeeId);
                        _order.Employee = employee;
                        RaisePropertyChanged("EmployeeId");
                        RaisePropertyChanged("LastName");
                        RaisePropertyChanged("FirstName");
                        RaisePropertyChanged("Title");
                    }
                }
                public string LastName
                {
                    get { return _order.Employee!=null? _order.Employee.LastName : string.Empty; }
                }
                public string FirstName
                {
                    get { return _order.Employee!=null? _order.Employee.FirstName : string.Empty;  }
                }
                public string Title
                {
                    get { return _order.Employee!=null? _order.Employee.Title : string.Empty;  }
                }
    
                public OrderViewModel(INorthwindDbContext ctx)
                {
                    this.Init(new Order(), ctx);
                }
    
                public OrderViewModel(Order order, INorthwindDbContext ctx)
                {
                    this.Init(order, ctx);
                }
    
                private void Init(Order order, INorthwindDbContext ctx)
                {
                    this._order = order;
                    this._ctx = ctx;
                }
    
                private void RaisePropertyChanged(string propname)
                {
                    if (PropertyChanged != null)
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propname));
                }
    
                public void NotifyChanges()
                {
                    foreach (var prop in typeof(OrderViewModel).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanRead))
                        RaisePropertyChanged(prop.Name);
                }
    
    
    
                public string Error
                {
                    get { return null; }
                }
    
                public string this[string columnName]
                {
                    get {
                        switch (columnName)
                        {
                            case "CustomerId":
                                if (_ctx.Customers.Find(CustomerId)==null)
                                    return "Invalid customer";
                                break;
    
                            case "EmployeeId":
                                if (_ctx.Employees.Find(EmployeeId)==null)
                                    return "Invalid employee";
                                break;
    
    
                        }
                        return null;
                    }
                }
    
            } 
