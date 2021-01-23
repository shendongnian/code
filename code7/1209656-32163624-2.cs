    public class Form1 : Form
    {
        //Declaration of Static Variable
        static string Value = "";
        public Form1()
        {
            
        }
    }
    //Code for using static variable
    Form1.Value = "text to be passed to the next Form";
    Form1 frm = new Form1();
    frm.Show();
