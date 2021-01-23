    public class PageData {
        public PageData(){
            Images = Images ?? new List<ImageData>();
        }
        
        // Some other other properties here if you want or need
        
        public List<ImageData> Images {get;set;}
    }
