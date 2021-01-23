    public partial class Form1 : Form
    {
        PictureBox[] PictureboxArray = new PictureBox[2];
        Image[] Rollimage = new Image[2];
        int[] pictureValues = new int[2];
        public Form1()
        {
            InitializeComponent();
            pictureValues[0] = 100;
            pictureValues[1] = 200;
            Rollimage[0] = Properties.Resources.TitleBar;
            Rollimage[1] = Properties.Resources.Untitled;
            PictureboxArray[0] = this.pictureBox1;
            PictureboxArray[1] = this.pictureBox2;
            PictureboxArray[1].Image = Rollimage[0];
            PictureboxArray[0].Image = Rollimage[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int total = 0;
            for(int i = 0;i<Rollimage.Length;i++)
            {
                foreach(var box in PictureboxArray)
                {
                    if(box.Image == Rollimage[i])
                    {
                        total += pictureValues[i];
                    }
                }
            }
            label1.Text = total.ToString();
        }
    }
