            LineSegment2D[] lines;
            using (var vector = new VectorOfPointF())
            {
                CvInvoke.HoughLines(cannyEdges, vector,
                    _arguments.HoughLineArgs.DistanceResolution,
                    Math.PI / _arguments.HoughLineArgs.AngleResolution,
                    _arguments.HoughLineArgs.Threshold);
                var linesList = new List<LineSegment2D>();
                for (var i = 0; i < vector.Size; i++)
                {
                    var rho = vector[i].X;
                    var theta = vector[i].Y;
                    var pt1 = new Point();
                    var pt2 = new Point();
                    var a = Math.Cos(theta);
                    var b = Math.Sin(theta);
                    var x0 = a * rho;
                    var y0 = b * rho;
                    pt1.X = (int)Math.Round(x0 + mat.Width * (-b));
                    pt1.Y = (int)Math.Round(y0 + mat.Height * (a));
                    pt2.X = (int)Math.Round(x0 - mat.Width * (-b));
                    pt2.Y = (int)Math.Round(y0 - mat.Height * (a));
                    linesList.Add(new LineSegment2D(pt1, pt2));
                }
                lines = linesList.ToArray();
            }
