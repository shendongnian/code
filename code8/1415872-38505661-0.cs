    public partial class Form2 : Form
    { 
    private void button3_Click(object sender, EventArgs e)
    {
        Button3.Enabled = false;
        Form2 p = new Form2(label1.Text);
        
        p.ShowDialog();
        
       
        //the code will stop here until you finish your work on form2
         Button3.Enabled=true;
    }
