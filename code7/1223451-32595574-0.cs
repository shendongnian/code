        using Microsoft.SqlServer.Types;
        using System.Data.Entity.Spatial;
        
        private static DbGeometry GetSimpleDbGeography(DbGeometry input)
        {
            // We can create geometry using Microsoft.SqlServer.Types.SqlGeometryBuilder
            // We have to use this to reconstruct the geometry we want from the input as DbGeometry.ExteriorRing() returns a LINESTRING which is no good to us
            SqlGeometryBuilder builder = new SqlGeometryBuilder();
            // We MUST set an SRID
            builder.SetSrid(0);
            OpenGisGeometryType ourType;
            // We must set the type
            if (input.SpatialTypeName.ToUpper() == "POLYGON")
                ourType = OpenGisGeometryType.Polygon;
            else if (input.SpatialTypeName.ToUpper() == "MULTIPOLYGON")
                ourType = OpenGisGeometryType.MultiPolygon;
            else
                throw new ArgumentException("Non Polygon received.");
            // Tell the Builder what we're creating
            builder.BeginGeometry(ourType);
            // This assumes we have a valid DbGeometry instance, otherwise .Value will cause an error
            int numberOfElements = input.ElementCount.Value;
            // Loop through each element, this will either be one (POLYGON) or more (MULTIPOLYGON)
            for (int i = 1; i < (numberOfElements + 1); i++)
            {
                // BeginGeometry only required for MULTIPOLYGON
                if (ourType == OpenGisGeometryType.MultiPolygon)
                {
                    // Begin a POLYGON geometry
                    builder.BeginGeometry(OpenGisGeometryType.Polygon);
                }
                // ElementAt() is not zero-based index
                DbGeometry element = input.ElementAt(i).ExteriorRing;
                // Start the figure with the first point
                builder.BeginFigure(element.StartPoint.XCoordinate.Value, element.StartPoint.YCoordinate.Value);
                // Lopp through remaining points
                for (int j = 2; j < (element.PointCount.Value + 1); j++)
                {
                    // PointAt() is not zero-based index
                    builder.AddLine(element.PointAt(j).XCoordinate.Value, element.PointAt(j).YCoordinate.Value);
                }
                // End the current polygon
                builder.EndFigure();
                // EndGeometry only required for MULTIPOLYGON
                if (ourType == OpenGisGeometryType.MultiPolygon)
                {
                    // End the current Geometry
                    builder.EndGeometry();
                }
            }
            // Finalise the geometry
            builder.EndGeometry();
            // Convert the construsted geometry back to a DbGeometry instance
            DbGeometry finalGeometry = DbGeometry.FromBinary(builder.ConstructedGeometry.STAsBinary().Buffer);
            return finalGeometry;
        }
