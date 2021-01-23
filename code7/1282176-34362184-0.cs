    private void Home_Load(object sender, EventArgs e)
    {
        string[] fileNo = File.ReadAllLines(@"..\..\images\Products\productListing.txt");
        PictureBox[] imageControl = new PictureBox[fileNo.Length];
        for (int i = 0; i < fileNo.Length; i++)
        {
            imageControl[i] = new PictureBox(); // initiate object first
            imageControl[i].Width = 400;  // you are accessing a null object here.
            imageControl[i].Height = 400;
    
            Bitmap image = new Bitmap(@"..\..\images\Products\" + i + ".jpg");
    
            imageControl[i].Dock = DockStyle.Fill;
            imageControl[i].Image = (Image)image;
    
            Console.WriteLine(i);
        }
    }
