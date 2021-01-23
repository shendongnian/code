    private void brushBtn_Click(object sender, EventArgs e)
    {
        //New form which will ask which brush type and the size 
        using(Form2 paintInfo = new Form2())
        {
            paintInfo.ShowDialog();  
            int brushType = paintInfo.BrushType;
        }
    }
    
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    
        int typeOfBrush;   
        public int BrushType 
        {
           get {return typeOfBrush;}
           set {typeOfBrush = value;}
        }
        private void circleBrushBtn_Click(object sender, EventArgs e)
        {
            this.BrushType = 1 ; 
        }
    }
