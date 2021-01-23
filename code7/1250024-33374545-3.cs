    public enum CustomerType
    {
        Customer1,
        Customer2
    }
    public class Customer
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public CustomerType Type {get; set; }
    }
    Customer c = new Customer();
    c.ItemID = 1;
    c.Name = "N1";
    c.BirthDate = DateTime.Now;
    c.Type = CustomerType.Customer1;
    BindingList<MyBase> tmpList = new BindingList<MyBase>();
    tmpList.Add(c);
    gridControl1.DataSource = tmpList;
