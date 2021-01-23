    public partial class ImageWithText : UserControl
    {
        public ImageWithText(Image image = null, string champName = null)
        {
            InitializeComponent();
            if(image != null)
            {
                ChampionImage.Image = image;
            }
            if(!string.IsNullOrEmpty(champName))
            {
                ChamptionName.Text = champName;
            }
        }
        private void ImageWithText_Load(object sender, EventArgs e)
        {
            //Get the Width of the usercontrol:
            int ucWidth = this.Width;
            int centerPoint = ucWidth / 2;
            //Place text in the center:
            int labelWidth = ChamptionName.Width;
            int labelCenter = labelWidth / 2;
            //Set the lable to the centerPoint and then shift half of the lable to the left!
            //We leave the Top value untouched since we only want to set the HORIZONTAL ALIGNMENT
            ChamptionName.Left = centerPoint - labelCenter;
        }
        public void SetChampionImage(Image image)
        {
            ChampionImage.Image = image;
            ChampionImage.SizeMode = PictureBoxSizeMode.StretchImage;
            Application.DoEvents();
        }
        public void SetChampionName(string name)
        {
            ChamptionName.Text = name;
            Application.DoEvents();
        }
    }
