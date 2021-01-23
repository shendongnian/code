    void PictureBox_Click(object sender, EventArgs e)
    {
        string theMap = (sender as PictureBox).Tag.ToString();
        
        if(mapChoices.Count > 3 || mapChoices.Contains(theMap))
           return;
        mapChoices.Add(theMap);
       
        PictureBox1.Image = Image.FromFile("../Debug/images/changed-image.png");
    }
