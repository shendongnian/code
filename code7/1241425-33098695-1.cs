    var data = from t in section
               select new SectionCoordinateViewModel
               {
                   SectionId = "section_" + t.Id,
                   Coordinate = new Coordinate
                   {
                      Xcoor = t.X,
                      Ycoor = t.Y
                   }
                };
