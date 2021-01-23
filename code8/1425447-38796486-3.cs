    public class AddForm
    {
        MyListForm listForm;
        public AddForm(MyListForm f)
        {
            InitializeComponent();
            listForm = f;
        }
        private void SaveVutton_Click(object sender, EventArgs e)
        {
            //perform validation and save data
            f.FillGrid();
        }
    }
