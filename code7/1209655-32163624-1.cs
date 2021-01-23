    public class Form1 : Form
    {
        //Declaration of Static Variable
        public string Value = "";
        public Form1()
        {
            
        }
    }
    //Code for using static variable
    Form1 frm = new Form1();
    frm.Value = "text to be passed to the next Form";
    frm.Show();
