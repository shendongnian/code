        // the representation of a photo within a result item
        class Photo
        {
            public int height { get; set; }
            public List<string> html_attributions { get; set; }
            public string photo_reference { get; set; }
            public int width { get; set; }
        }
        // I represent a result item
        class ResultItem
        {
            public string id { get; set; }
            public string name { get; set; }
            // the added icon
            public string icon { get; set; }
            // the added photos collection, could also be an array
            public List<Photo> photos { get; set; }
        }
