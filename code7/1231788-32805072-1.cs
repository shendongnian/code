    public class Form2 : Form
    {
        public Form2(string name , string pay)
        {
            Form form3 = new Form3(name, pay);
            form3.ShowDialog();
        }
    }
    
