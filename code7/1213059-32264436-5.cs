    public partial class UserControl1 : UserControl
    {
 
        public PictureBox ChildPictureBox { get; set; }        
        public UserControl1()
        {
            InitializeComponent();
            ChildPictureBox = pictureBox1;
        }
        //----
    }
