    public class ImageResult
    {
        string ImageUrl { get; set; }
        string Title { get; set; }
    }
    
    public ImageResult GetImage(string imageTitle)
    {                
        ImageResult result = new ImageResult();
    
        using (WebClient client = new WebClient())
        {
            var uri = "https://en.wikipedia.org/w/api.php?action=query&format=json&prop=pageimages&pithumbsize=400&titles="+imageTitle;
            string requestUrl = string.Format(uri, imageTitle);
            var response = client.DownloadString(new Uri(uri));
            var responseJson = JsonConvert.DeserializeObject<ImgRootobject>(response);
            var firstKey = responseJson.query.pages.First().Key;
            
            result.ImageUrl = responseJson.query.pages[firstKey].thumbnail.source;
            result.Title = responseJson.query.pages[firstKey].title;
    
            var hash = uri.GetHashCode();
    
        }
        return result;
    }
        
    private void button1_Click(object sender, EventArgs e)
    {
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        
        var imageResult = _imageService.GetImage(textBox1.Text);
        
        pictureBox1.LoadAsync(imageResult.ImageUrl);
        label1.Text = imageResult.Title;
    }
