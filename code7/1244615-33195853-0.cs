    class Form2 : Form
    {
        //Variables
        private Form _ParentForm; //Add this here
        //Constructor
        public Form2(Form parentForm)
        {
            InitalizeComponent();
            _ParentForm = parentForm; //Add this here
        }
    }
