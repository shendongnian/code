    var rois = new List<Rectangle>(); // List of rois
    var imageparts = new List<Image<Gray,byte>>(); // List of extracted image parts
    
    using (var image = new Image<Gray, byte>(...))
    {
        foreach (var roi in rois)
        {
        	image.ROI = roi;
        	imageparts.Add(image.Copy());	
        }
    }
