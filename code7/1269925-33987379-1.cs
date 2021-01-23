    PictureBox[] boxes = new PictureBox[100];
    for (int i = 0; i < boxes.Length; i++)
    {
        boxes[i] = new PictureBox; //set the pointer to a new PictureBox instance
        boxes[i]./*propertyToChange*/ = /*value*/;
        boxes[i].Image = Image.FromFile(@"Path\To\File.png"); //for setting its image
    }
    //And of course you need to add those boxes to your form ;)
    //Presuming you're doing it in the form
    this.Controls.AddRange(boxes);
