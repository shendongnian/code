namespace list_inside_list
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            //First we load the list of Orders to datarepeater1
            Program.CompanyContext _context = new Program.CompanyContext();
            List<list_inside_list.Program.Order> listOrders = _context.Order.ToList();
            program_OrderBindingSource1.DataSource = listOrders;
            //I don´t know why, but we need to load the list of items as well, although we never use the listItems variable
            List<list_inside_list.Program.Item> listItems = _context.Item.ToList();
            
            /* 
             * 1. We will loop through all the datarepater1 items (which is fed with listOrders)
             * 2. We assign currItem as datarepeater1.CurrentItem in order to "select" the current item at index j,
             *    although we will never user currItem
             * 3. We tell the program that of the current datarepeater item we want use the current Order object
             * 4. We go through each of the currentOrder.items and print the itemName
             * 
            */
            DataRepeaterItem currItem = new DataRepeaterItem();
            for (int j = 0; j < this.dataRepeater1.ItemCount; j++)
            {
                this.dataRepeater1.CurrentItemIndex = j;
                currItem = dataRepeater1.CurrentItem;               
                var currentOrder = (list_inside_list.Program.Order)program_OrderBindingSource1.Current;
                foreach (var item in currentOrder.items)
                {
                    dataRepeater1.CurrentItem.Controls["richTextBox1"].Text 
                        = dataRepeater1.CurrentItem.Controls["richTextBox1"].Text + item.itemName + "\n";
                }
                
            }
        }
    }
}
