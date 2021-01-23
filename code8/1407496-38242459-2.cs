    public partial class Form1 : Form
    {
        public Form1()
        {
            // This one is an instance of Form3
            Form3 newForm = new Form3();
            newForm.SomethingHappens += RaiseHere;
        }
    
        public void RaiseHere(object sender, EventArgs e)
        {
            // Do something...
        }
    }
    
    public partial class Form2 : Form
    {
        public Form2()
        {
            // This one is NOT the same as on Form1. Its a NEW form.
            Form3 newForm = new Form3();
            newForm.Show();
        }
    }
    
    public partial class Form3 : Form
    {
        public event EventHandler SomethingHappens;
    
        public Form3()
        {
            //...
        }
    }
