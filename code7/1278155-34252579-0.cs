    public partial class Form1 : Form
    {
        UserControl[] userControls = new []{ 
            new UserControl1(), 
            new UserControl2(),
            new UserControl3(),
            new UserControl4()
        };
        UserControl previous;
        UserControl current;
    
        public Form1()
        {
            InitializeComponent();
    
            foreach(var uc in UserControls)
            {
                uc.Click += ShowPrevControl_Click;
                Controls.Add(uc);
            }
        }
    
