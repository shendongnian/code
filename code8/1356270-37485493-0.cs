    public interface IPresenter
    {
        void Init();
        void SetSelectedCustomer(int customerId);
        IEnumerable GetCustomers();
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
    }
