    public partial class Form2 : Form
    {
        public Form2(ListViewItem item)
        {
            InitializeComponent();
            textBox1.Text = item.Text;   // item.Subitems[index].Text if you want the value of subitems
        }
    }
