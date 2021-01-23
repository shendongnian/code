    public List<Image> GetImageOnId(int sessionID)
    {
        return (
          from sessionImage in _db.MtoMImgs
          join  image in _db.Images on sessionImage.ImageId equals image.Id
          where sessionImage.SessionId == sessionID 
          select  image
        ).ToList();
    }
