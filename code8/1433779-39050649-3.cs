    public partial class Form1 : Form
    {
        private Class1 _class1;
        public Form1()
        {
            bool adding = false;
            InitializeComponent();
            _class1 = new Class1(); // logic class instance
            _class1.BindingList.ListChanged += (sender, e) =>
            {
                Invoke((MethodInvoker)(() =>
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded && !adding)
                    {
                        // Remove and re-insert newly added item, but on the UI thread
                        string value = _class1.BindingList[e.NewIndex];
                        _class1.BindingList.RemoveAt(e.NewIndex);
                        adding = true;
                        _class1.BindingList.Insert(e.NewIndex, value);
                        adding = false;
                    }
                }));
            };
            listBox1.DataSource = _class1.BindingList;
        }
        // ...
    }
