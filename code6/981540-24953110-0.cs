    public delegate void ModifyCollectionHandler(string parameter);
    public delegate void ClearCollectionHandler();
    public partial class Form1 : Form
    {
        public List<string> folderList;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2()
            form.ClearItem+=form_ClearItem;
            form.AddItem+=form_AddItem;
            form.DeleteItem+=form_DeleteItem;
        }
        void form_DeleteItem(string parameter)
        {
            if (folderList == null)
                return;
            folderList.Remove(parameter);
        }
        void form_AddItem(string parameter)
        {
            if (folderList == null)
                folderList = new List<string>();
            folderList.Add(parameter);
        }
        void form_ClearItem()
        {
            if (folderList != null)
                folderList.Clear();
        }
    }
    public partial class Form2 : Form
    {
        public event ModifyCollectionHandler AddItem;
        public event ModifyCollectionHandler DeleteItem;
        public event ClearCollectionHandler ClearItem;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClearItem != null)
                ClearItem();
        }
    }
