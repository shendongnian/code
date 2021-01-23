    public class ImageVM { // view-model for data-binding
        public string ImageUrl { get; set; }
    }
    ...
    var images = LoadImages(); // returns a list of ImageVM instances
    grid.DataSource = images;
    grid.DataBind();
