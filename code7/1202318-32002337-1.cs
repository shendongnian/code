    class Controller
    {
        private List<Result> _orders;
        public IList<Result> Orders
        {
            get
            {
                return _orders;
            }
        }
        public Controller()
        {
            using (var DataContext = new DataClasses1DataContext())
            {
                _orders = DataContext.tblOrder.Select(o=> 
                          new Result
                          {
                              ID = o.orderID,
                              OrderName = o.orderName,
                              ItemNames = o.tblItem.Select(item=> item.itemName)
                          }).ToList();
            }
        }
    }
