    for(int i=0; i<yourCount; i++)
    {
      PictureBox pic=new PictureBox();
      pic.Name=i.ToString();
      pics.Click += PickClicked;
    }
