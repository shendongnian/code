    public partial class MyUserControl : UserControl
    {
        public MyUserControl(BindingContext bindingContext, DataSet dataSet)
        {
            this.BindingContext = bindingContext;
            InitializeComponent();
            myTextBox.DataBindings.Add("Text", dataSet, "Master.Master_Detail.DetailField");
        }
    }
