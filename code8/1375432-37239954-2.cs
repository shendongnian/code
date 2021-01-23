     public partial class Home : Form { 
    
        public Home() 
        { 
          InitializeComponent(); 
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Task addnew = new Task();
            addnew.Show();
        }
        private void button2_Click(object sender, EventArgs h)
        {
            History history = new History();
            history.Show();
         }
        private void button3_Click(object sender, EventArgs v)
        {
            Evaluate evaluate = new Evaluate();
            evaluate.Show();
        }
     }
