    class AlbumImage
    {
        public string AlbumId
        {
            get;
            set;
        }
        public string ImageUrl
        {
            get;
            set;
        }
    }
    [TestMethod]
    public void TestGetImages()
    {
        var results = new List<AlbumImage>
        {
            new AlbumImage { AlbumId = "1", ImageUrl = "123.png" },
            new AlbumImage { AlbumId = "1", ImageUrl = "456.png" },
            new AlbumImage { AlbumId = "1", ImageUrl = "789.png" },
            new AlbumImage { AlbumId = "2", ImageUrl = "321.png" },
            new AlbumImage { AlbumId = "2", ImageUrl = "654.png" },
            new AlbumImage { AlbumId = "2", ImageUrl = "987.png" }
        };
        var imageResults = results.GroupBy(g => g.AlbumId).Select(grp => grp.First()).ToList();
    }
