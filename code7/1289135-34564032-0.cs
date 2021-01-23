        public FileContentResult GetImage(int id)
	    {
            InspectionPhoto image = db.InspectionPhotoes.Find(id);
		    byte[] byteArray = image.ImageBytes ;
			return byteArray != null
				? new FileContentResult(byteArray, "image/jpeg")
				: null;
	    }
