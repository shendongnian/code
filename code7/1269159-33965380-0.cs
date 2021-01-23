    //This is how you can implement it using yield return to return one image at a time
    public IEnumerable<Task<string>> GetPerItemAsync(IEnumerable<string> images)
    {
        foreach (var image in images)
        {
           yield return LoadImage(image);
        }
     }
        
     public static Task<string> LoadImage(string image)
     {
         var result = image.Trim(); // Some complex business logic on the image, NOT
                    
         return new Task<string>(() => result);
      }
      //Call your method in you client
      //First, get your images from the data source
      var listOfimages = Context.Images.ToList();
      //Get results
      var result = GetPerItemAsync(listOfimages).FirstOrDefault();
