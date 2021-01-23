    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Load a bitmap image here
                // your code here
    
                // Convert to base64 encoded string
                string base64Image = ImageToBase64(myImage, System.Drawing.Imaging.ImageFormat.Jpeg);
    
                // Post image to upload handler
                using (WebClient client = new WebClient())
                {
                    byte[] response = client.UploadValues("http://localhost/image/index.php", new NameValueCollection()
                    {
                        { "myImageData", base64Image }
                    });
    
                    Console.WriteLine("Server Said: " + System.Text.Encoding.Default.GetString(response));
                }
    
                Console.ReadKey();
            }
    
            static System.Drawing.Image GetImage(string filePath)
            {
                WebClient l_WebClient = new WebClient();
                byte[] l_imageBytes = l_WebClient.DownloadData(filePath);
                MemoryStream l_stream = new MemoryStream(l_imageBytes);
                return Image.FromStream(l_stream);
            }
    
            static string ImageToBase64(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat format)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Convert Image to byte[]
                    image.Save(ms, format);
                    byte[] imageBytes = ms.ToArray();
    
                    // Convert byte[] to Base64 String
                    return Convert.ToBase64String(imageBytes);
                }
            }
        }
    }
