    //Loop through each image
    for(int i = 0; i < testTemp[i].length; i++)
    {
    	//Create a picture box
    	PictureBox pictureBox = new PictureBox();
    	
    	pictureBox.BorderStyle = BorderStyle.None;
    	pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
    	
    	//Load the image date
    	pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + testTemp[i]);
    	
    	//Set it's size
    	pictureBox.Size = new Size(PICTURE_WIDTH, PICTURE_HEIGHT);
    	
    	//Position the picture at (330,500) with a left offset of how many images we've gone through so far
    	pictureBox.Location = new Point(330 + (i * PICTURE_WIDTH), 500);
    	
    	//Add the picture box to the list of controls
    	this.Controls.Add(pictureBox);
    }
