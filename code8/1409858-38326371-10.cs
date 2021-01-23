    private void Form1_Load(object sender, EventArgs e)
    {
        ImageList img = new ImageList();
        img.ImageSize = new Size(30, 30);
    
        var paths = new List<string> { @"C:\pictures\num.png", @"C:\pictures\cat.png" };
        paths.ForEach(path => img.Images.Add(MediaTypeNames.Image.FromFile(path)));
    
        lvMoveFrom.SmallImageList = img;
    
        for (int i = 0; i < ColNamesForm1.Length; i++)
        {
            if (ColNamesForm1[i].ToString().Substring(0, 4).ToUpper() == "COL_"
                || Regex.IsMatch(ColNamesForm1[i].ToString().Substring(4, 1), @"^\d+$"))
            {
                continue;
            }
    
            var image = ColNamesForm1[i].ToString().EndsWith("(num)")
                            ? 0 // corresponds with the position of the image in the ImageList
                            : 1;
    
            lvMoveFrom.Items.Add(ColNamesForm1[i].ToString(), image);    
        }
    }
