    public class Order_Form : Form
    {
        public Order_Form()
        {
            // ...
        }
    
        public string clientName = String.Empty;
    
        public void GetClientName()
        {
            // Pass the instance of the Order_Form
            Client_form cform = new Client_form(this);
            cform.Show();
        }
    }
    
    public class Client_form
    {
        public Client_form(Order_Form instance)
        {
            // Use the passed instance to access your clientName
            instance.clientName = "your string back";
        }
    }
