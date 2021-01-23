    // Create a instance of the modal form
    using(var frm = new MyModalForm())
    {
        // Initialize some properties
        frm.Text = "Product catalog";
        ...
        // Show the modal form. At this time, the code execution is suspended until
        // the modal form is closed
        frm.ShowDialog(this);
        
        // Once the form is closed, it remains instanciated and can still be used
        if (frm.RefreshRequired)
        {
            // Perform the datagrid refresh
        }
    }
    // At this time, the form is disposed because of the using block, and
    // all the resources it used are cleaned
    public class MyModalForm : ...
    {
        ...
        public MyModalForm()
        {
            this.InitializeComponent();
        }
        
        // Set this flag to true or false according to the
        // operations done in the modal form
        // (in the event code of the buttons for example)
        public bool RefreshRequired = false;
        ...
    }
