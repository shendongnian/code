    public class Customer : IEquatable<Customer>
    {
        ...
    }
    public class FormEditCustomer : ...
    {
        public Customer OriginalCustomer {get; set;}
        private bool CanExit()
        {
            Customer editedCustomer = GetEditedData();
            if (this.OriginalCustomer == null)
            {   // new customer
                return ProcessNewCustomer(editedCustomer);
            }
            else
            {   // existing customer
                if (!this.OriginalCustomer.Equals(editedCustomer))
                {   // customer changed
                    return ProcessChanges(editedCustomer);
                }
                else
                {    // no changes:
                     return RestoreCustomer(this.originalCustomer); // only if useful
                }
            }
        }
    }
            
    
