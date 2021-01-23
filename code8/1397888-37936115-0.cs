    namespace Test
   {
     public partial class Form2 : Form
     {
        private List<TestData> _list;
        public Form2 (List<TestData> list)
        {
            InitializeComponent();
            this._list = list;
        }
    }
