    class Form2 : Form
    {
        //Variables
        private Form1 _ParentForm; //Add this here
        //Constructor
        public Form2(Form1 parentForm)
        {
            InitalizeComponent();
            _ParentForm = parentForm; //Add this here
        }
    }
