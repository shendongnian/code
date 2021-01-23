	public class Column {
		public string Name;
		public string Type;
		public object Content;
	}
    public ActionResult PostAction(ColumnViewModel model)
    {
        var dto = new Column();
        switch (model.Type)
        {
            case "int": 
                dto.Content = dto.ContentInt;
            case "geo": 
                dto.Content = dto.ContentGeoPoint;
                break;
           // etc
        }
    }
