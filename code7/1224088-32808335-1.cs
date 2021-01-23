    public class Form1 : Form
    {
        MyObject myObject = new MyObject();
        public MyForm()
        {
            InitializeComponent();
            ExpandableCollectionPropertyDescriptor.CollectionChanged += CollectionChanged();
            propertyGrid.SelectedObject = myObject;
        }
        private void CollectionChanged(object sender, EventArgs e)
        {
            if (sender == myObject)
                propertyGrid.SelectedObject = myObject;
        }
    }
