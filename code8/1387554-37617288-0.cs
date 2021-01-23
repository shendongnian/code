    public partial class Form1 : Form
    {
        // list of ListBoxes - makes it easy to work out which one to add filepath item to
        List<ListBox> boxes = new List<ListBox>();
        public Form1()
        {
            InitializeComponent();
            boxes.Add(this.listBox1);
            boxes.Add(this.listBox2);
            boxes.Add(this.listBox3);
            boxes.Add(this.listBox4);
            // populate the ListBoxes
            populateLists();
        }
        public void populateLists()
        {
            // simulate getting data from filesystem
            List<string[]> n = new List<string[]>();
            n.Add(new string[] { "C:", "foo1", "bar1", "test1.txt" });
            n.Add(new string[] { "D:", "foo2", "bar2", "test2.txt" });
            n.Add(new string[] { "E:", "foo3", "bar3", "test3.txt" });
            n.Add(new string[] { "F:", "foo4", "bar4", "test4.txt" });
            n.Add(new string[] { "G:", "foo5", "bar5", "test5.txt" });
            // loop through list items
            for (var i = 0; i < n.Count; i++)
            {
            // loop through arrays for each list item
                for (var j = 0; j < n[i].Length; j++)
                {
                boxes[j].Items.Add(n[i][j]);
                }
            }
        }
    }
