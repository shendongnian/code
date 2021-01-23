    public class Form2
    {
        public ListViewItem[] Items{get;set;}
    
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Items[0].SubItems[0].Text; // or your logic here in this handler            
        }
        //your code
    }
