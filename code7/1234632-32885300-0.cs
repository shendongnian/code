    WellViewModel model = new WellViewModel();
    model.Wells = new List<WellModel>();
    model.Annotations = new List<AnnotationModel>();
    while (rdr.Read())
    {
        model.Wells.Add(new WellModel { // set values here };
    }
