    [WebMethod]
        public string SaveEventImage(string ImageByteArray, string ImageTitle)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(ImageByteArray);
                File.WriteAllBytes(EVTImagePath + ImageTitle + ".jpg",bytes);
                return "true";
            }
            catch
            {
                return "false";
            }
        }
