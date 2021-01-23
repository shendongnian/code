    public partial class Form2 : Form
    {
        List<Item> itemList = new List<Item>();
        
        public Context c = new Context();
        public Form2()
        {
            InitializeComponent();
            
            itemList.Add(new Item("First"));
            itemList.Add(new Item("Second"));
            itemList.Add(new Item("Third" ));
            comboBox1.DataSource = itemList;
            comboBox1.DisplayMember = "Title";
            foreach (var itemView in itemList)
            {
                itemView.onClick += this.ItemClicked;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = (ComboBox) sender;
            flowLayoutPanel1.Controls.Add(itemList[s.SelectedIndex].ThisImage);
        }
        private void ItemClicked(object sender, EventArgs e)
        {
            Item v = (Item)sender;
            AssignTextBox(v.Title);
        }
        public void AssignTextBox(string text)
        {
            textBox1.Text = text;
        }
    }
    public class Item
    {
        public string Title { get; set; }
        public PictureBox ThisImage { get; set; }
        public delegate void clicked(object sender, EventArgs e);
        public event clicked onClick;
        public Item(string title)
        {
            Title = title;
            ThisImage = new PictureBox();
            ThisImage.Paint += Paint_This;
            ThisImage.Click += onClicked;
        }
        public void onClicked(object sender, EventArgs e)
        {
            if (onClick != null)
                onClick(this, e);
        }
        private void Paint_This(object sender, PaintEventArgs e)
        {
            using (Font f = new Font("Verdana", 14))
            {
                e.Graphics.DrawString(Title, f, Brushes.Black, new Point(1,1));
            }
        }
    }
