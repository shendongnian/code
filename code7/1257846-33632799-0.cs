    private void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false; // to prevent a new download until you have finished the old one
        XDocument xmlDocument = XDocument.Load(url1_Image);
        var images = (from page in xmlDocument.Descendants("page")
                      select new AllImage
                      {
                          Title = page.Attribute("title").Value,
                          Imagerepository = page.Attribute("imagerepository").Value,
                          Url = page.Element("imageinfo").Element("ii").Attribute("url").Value
                      });
        ShowImages(images);
    };
    private void ShowImages(IEnumerable<AllImage> images)
    {
        var image = images.First();
        label1.Text = image.Title;
        pictureBox1.LoadAsync(image.Url); // asynchronous loading
    }
