    namespace CheckListBoxSimple_C_Sharp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            }
            private const int maxNumberOfCheckedItems = 1; 
            void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                CheckedListBox items = (CheckedListBox)sender;
                if (items.CheckedItems.Count > (maxNumberOfCheckedItems - 1))
                {
                    e.NewValue = CheckState.Unchecked;
                }            
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                checkedListBox1.Items.AddRange(new string[] { "John", "Paul", "George", "Ringo" });
    
                checkedListBox1.SetItemChecked(1, false);
                checkedListBox1.SetItemChecked(3, false);
            }
        }
    }
