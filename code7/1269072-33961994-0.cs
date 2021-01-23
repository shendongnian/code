    public delegate void SendTextF2(string YourStringFromTextBox);
    public partial class Form2 : Form
    {
        public event SendTextF2 UISendTextHandlerF2;
        public Form2(TextBox s)
        {/*unchange*/}
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(UISendTextHandlerF2!=null)
                UISendTextHandlerF2(textBox1.Text);
        }
    }
    
