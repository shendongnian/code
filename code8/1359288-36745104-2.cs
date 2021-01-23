    public partial class Form1 : Form
    {
        private Form2 form2;
        public Form1()
        {
            form2 = new Form2();
            form2.ItemAdded += OnItemAdded;
            form2.Disposed += (sender, args) => form2.ItemAdded -= OnItemAdded;
        }
        private void OnItemAdded(object sender, ItemAddedEventArgs e)
        {
            listview1.Items.Add(new Item(e.Issue, e.Comment));
        }
    }
