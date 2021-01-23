    using Newtonsoft.Json;
    
    public class SearchData 
    {
        public string UploadDate { get; set; }
        public List<UserImages> Images { get; set; }
        public bool success { get; set; }
    }
    
    public class UserImages
    {
        public string Filename { get; set; }
        public string FileId { get; set; }
    }
    
    var result= JsonConvert.DeserializeObject<List<SearchData>>("JsonString")
