      public partial class Form1 : Form
    {
        List<Bitmap> picturesList = new List<Bitmap>(); //Array of pictures
        Random random = new Random(); 
        public Form1()
        {
            InitializeComponent();
            //Load all pictures from resources into array
            picturesList.Add(Properties.Resources.pic1);
            picturesList.Add(Properties.Resources.pic2);
            picturesList.Add(Properties.Resources.pic3);
            //Set random image into picture box
            RandomChangeImage();
        }
        public void RandomChangeImage()
        {
            //Generate random number. (random index between 0 - array.count )
            int randomIndex = random.Next(0, picturesList.Count);
            //Set random image from array
            YourPictureBoxName.Image = picturesList[randomIndex];
        }
    }
