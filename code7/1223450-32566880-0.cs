    //handling of LineStrings (I use this to build WPF Path for example)
            private static object LineStringToSomething(DbGeometry sqlGeometry)
            {
                object result = null;
                DbGeometry curPoint;
                System.Windows.Point startPoint = new System.Windows.Point()
                {
                    X = sqlGeometry.PointAt(1).XCoordinate.Value,
                    Y = sqlGeometry.PointAt(1).YCoordinate.Value
                };
    
                curPoint = sqlGeometry.PointAt(1);
    
                for (int i = 2; i <= sqlGeometry.PointCount; i++)
                {
                    //Do something with the line between curPoint and PointAt(i)
    
                    curPoint = sqlGeometry.PointAt(i);
                }
    
                return result;
            }
    
            //Defines an extension method on DbGeometry objects
            //usage :
            // myOwnGeometry = myGeo.AsSimpleGeometry();
            public static object AsSimpleGeometry(this DbGeometry sqlGeometry)
            {
                object result = null;
    
                switch (sqlGeometry.SpatialTypeName.ToLower())
                {
                    case "point":
                        //Here we found a point
    
                        return result;
    
                    case "polygon":
                        // A Spacial Polygon is a collection of Rings
                        // A Ring is a Closed LineString, i.e. a collection of lines.
                        List<object> lotOfGeos = new List<object>();
                        // Outer Ring
                        return LineStringToSomething(sqlGeometry.ExteriorRing);
    
                        // Inner Rings (holes in the donut)
                        for (int i = 1; i <= sqlGeometry.InteriorRingCount; i++)
                        {
                            //just comment to ignore the inner loops
                            lotOfGeos.Add(LineStringToSomething(sqlGeometry.InteriorRingAt(i)));
                        }
    
                        return lotOfGeos;
    
                    case "linestring":
                        // Return a PathFigure
                        return LineStringToSomething(sqlGeometry);
    
                    case "multipoint":
                    case "multilinestring":
                    case "multipolygon":
                    case "geometrycollection":
                        //Here we handle a collection of points, polygons and/or lines
                        List<object> moreGeos = new List<object>();
                        for (int i = 1; i <= sqlGeometry.ElementCount.Value; i++)
                        {
                            //Simply calling the same method on each item
                            moreGeos.Add(sqlGeometry.ElementAt(i).AsSimpleGeometry());
                        }
    
                        return moreGeos;
    
                    default:
                        // Unrecognized Type
                        // Shall not happen
                        return null;
                }
            }
