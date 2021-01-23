    public class Room {
        public int Id {get; set;}
        public virtual List<Image> Images {get; set; }
    }
    public void NoLazyLoadingAndNoEagerLoading()
    {
      var _db = new dbContext();
      var rooms = _db.Rooms.ToList();
      //Now lazy loading should kick in,
      //Entity framework will make more calls to the db and return Images
      Assert.IsFalse(rooms.Any(x => x.Images != null));
      _db.Dispose();
    }
