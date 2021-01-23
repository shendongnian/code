    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dictionary<string, UserControl1> myControls = new Dictionary<string, UserControl1>();
        private void Form1_Load(object sender, EventArgs e)
        {
            // you could create the controls manually (i.e. not in designer)
            //  add them to a dictionary
            //  and also add them to the form, or whatever container you want
            for (int i = 0; i < 40; i++)
            {
                var newControl = new UserControl1
                {
                    Top = (i%10)*30,
                    Left = (i/10)*200,
                };
                myControls.Add("iButton" + ("ABCD"[(i / 10)]) + (i % 10), newControl);
                this.Controls.Add(newControl);
            }
            // now you can reference any of these controls like this:
            var letter = "B";
            var num = "8";
            var buttonItem = myControls["iButton" + letter + num].iButtonItem;
        }
    }
