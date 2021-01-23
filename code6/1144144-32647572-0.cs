<!--language: c# -->public class CustomersVm : INotifyPropertyChange
{ // just to point out, that you're using a VM class here   
   private ObservableCollection<Customer> _customers;
   public ObservableCollection<Customer> Customers
   { // since you're binding this to your listbox, DON'T change the reference during runtime
       get { return _customers ?? (_customers = new ObservableCollection<Customer>());
   }
   // here comes your loading logic
   public void RefreshCustomers()
   {
       var customers = LoadCustomersFromDb(); // contains now a result set of model classes
       Customers.Clear(); //Clear the collection instead of creating it again.
       foreach(var customer in customers)
           Customers.Add(customer);
   }
}
