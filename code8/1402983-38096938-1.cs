    public class InvoiceForm : OrderForm {
        public InvoiceForm() : base(){ // : base() executes the constructor of the superclass
            //all controls in the `OrderForm` class are added because we called base().
            var invoiceControl = new Label() { ... };
            this.Controls.Add(invoiceControl);
    
            //now in total your form will count 4 controls
        }
    }
