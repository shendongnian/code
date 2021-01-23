    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fillListViewSoulpets();
        }
        private void fillListViewSoulpets()
        {
            soulpets.Items.Clear(); //it should already be empty
            soulpets.Items.Add(
                new ListViewItem({ "Tough", "Ent", "Rare" }); 
            );
        }
    }
           
            
     
