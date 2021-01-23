    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int TableNum { get; set; }
        public string Notes { get; set; }
        public double Discount { get; set; }
        public string EmpName { get; set; }
        public virtual ICollection<MenuItemViewModel> MenuItems { get; set; }  //renamed to plural  
    }
