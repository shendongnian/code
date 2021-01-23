        class ProductModel
        {
           public int id {get; set;}
           public string name {get; set;}
           public string price {get; set;}
           public IList<ImageModel> images {get; set;}
        }
        class ImageModel
        {
           public int id {get; set;}
           public string imageUrl {get; set;}
        }
