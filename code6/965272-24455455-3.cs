    public IEnumerable<Photo> GetPhotos (int album_id)
		{
			List<Filter> filters = new List<Filter> () { 
				new Filter{
					PropertyName = "Album_Id",
					Operation = Filter.Op.Equals,
					Value = album_id
				}
			};
			return db.GetItems<Photo>(filters);
		}
