        void TessellationSink.AddTriangles(Triangle[] triangles)
        {
            // Add Tessellated triangles to the opened GeometrySink
            foreach (var triangle in triangles)
            {
                GeometrySink.BeginFigure(triangle.Point1, FigureBegin.Filled);
                GeometrySink.AddLine(triangle.Point2);
                GeometrySink.AddLine(triangle.Point3);
                GeometrySink.EndFigure(FigureEnd.Closed);                
            }
        }
