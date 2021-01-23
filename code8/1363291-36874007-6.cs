    public class Productlistdata
    {
        public string id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string qty { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string type { get; set; }
        public string full_productname { get; set; }
    
        public async void CheckImage()
        {
            bool imageexist = false;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(image));
                using (var response = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null)))
                {
    
                    int imagelength = Convert.ToInt32(response.ContentLength);
                    if (imagelength > 0)
                        imageexist = true;
                    else
                        imageexist = false;
                }
            }
            catch (Exception)
            {
                imageexist = false;
            }
            if (!imageexist)
            {
                image = "Images/NoDataImages/ico-no-orders.png";
            }
        }
    }
