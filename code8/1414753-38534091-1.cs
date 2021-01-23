    public SomeReturnValue OpenCustomerForEdit(Customer customer)
    { 
         var form = MyStaticClass.FormOpener.GetForm<EditCustomerForm>();
         form.SetCustomer(customer);
         var result = MyStaticClass.FormOpener.ShowModalForm(form);
         return (SomeReturnValue) result;
    }
