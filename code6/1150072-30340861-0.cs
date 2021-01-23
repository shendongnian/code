                PathGeometry pg1 = new PathGeometry();
                PathFigure pf1 = new PathFigure()
                {
                    StartPoint = new Point(Convert.ToDouble(middle) + 500, Convert.ToDouble(middle) + 500)
                };
                PathSegmentCollection psc1= new PathSegmentCollection();
                QuadraticBezierSegment arcs1 = new QuadraticBezierSegment()
                {
                    //Point1 = new Point(100, 560),
                    Point1 = new Point(150, 480),
                    Point2 = new Point(pf.StartPoint.X - 300, pf.StartPoint.Y + 200)
                };
                psc1.Add(arcs1);
                pf1.Segments = psc1;
                pg1.Figures.Add(pf1);
                Path spiral1 = new Path()
                {
                    Data = pg1,
                    Stroke = Brushes.White,
                    StrokeThickness = 1.5
                };
                MainScrn.Children.Add(spiral1);
                Rectangle[] pnt = new Rectangle[30];
                float growth = (float)1 / (float)30;
                float loc = 0;
                MessageBox.Show(growth.ToString());
                double lenOfpath = 0;
                Point pntA = new Point(0, 0);
                int segments = 8; segments++;
                float avgspace = 0;
                for (int length = 0; length < pnt.Count(); length++)
                {
                    pnt[length] = new Rectangle();
                    pnt[length].Fill = Brushes.Red;
                    pnt[length].Width = 10;
                    pnt[length].Height = 10;
                    double t = loc;
                    double left = (1 - t) * (1 - t) * pf.StartPoint.X + 2 * (1 - t) * t * arcs1.Point1.X + t * t * arcs1.Point2.X;
                    double top = (1 - t) * (1 - t) * pf.StartPoint.Y + 2 * (1 - t) * t * arcs1.Point1.Y + t * t * arcs1.Point2.Y;
                    MainScrn.Children.Add(pnt[length]);
                    Canvas.SetLeft(pnt[length], left);
                    Canvas.SetTop(pnt[length], top);
                    loc = loc + growth;
                    if (length > 0)
                    {
                        double x10 = Canvas.GetLeft(pnt[length - 1]);
                        double x20 = Canvas.GetLeft(pnt[length]);
                        double y10 = Canvas.GetTop(pnt[length - 1]);
                        double y20 = Canvas.GetTop(pnt[length]);
                        lenOfpath = lenOfpath + Math.Sqrt(Math.Pow(x20 - x10, 2) + Math.Pow(y20 - y10, 2));
                        avgspace = ((float)lenOfpath / (float)segments);
                    }
                }
                for (int length = 1; length < pnt.Count(); length++)
                {
    
                    double total = 0;
                    double[] smallestpos = new double[pnt.Count()-1];
                    for (int digger = length + 1; digger < pnt.Count(); digger++)
                    {
                        double x11 = Canvas.GetLeft(pnt[length]);
                        double x22 = Canvas.GetLeft(pnt[digger]);
                        double y11 = Canvas.GetTop(pnt[length]);
                        double y22 = Canvas.GetTop(pnt[digger]);
                        smallestpos[digger-1] = Math.Sqrt(Math.Pow(x22 - x11, 2) + Math.Pow(y22 - y11, 2));
                    }
                    int takeposition = FindClosest(avgspace, smallestpos);
                    double min = smallestpos[takeposition];
                    while (length < (takeposition+1))
                    {
                        pnt[length].Visibility = System.Windows.Visibility.Hidden;
                        length++;
                    }
                }    
            }
            public static int FindClosest(float given_number, double[] listofflts)
            {
                // Start min_delta with first element because it's safer
                int min_index = 0;
                double min_delta = listofflts[0] - given_number;
                // Take absolute value of the min_delta
                if (min_delta < 0)
                {
                    min_delta = min_delta * (-1);
                }
    
                // Iterate through the list of integers to find the minimal delta
                // Skip first element because min_delta is set with first element's
                for (int index = 1; index < listofflts.Count(); index++)
                {
                    float cur_delta = (float)listofflts[index] - (float)given_number;
                    // Take absolute value of the current delta
                    if (cur_delta < 0)
                    {
                        cur_delta = cur_delta * (-1);
                    }
    
                    // Update the minimum delta and save the index
                    if (cur_delta < min_delta)
                    {
                        min_delta = cur_delta;
                        min_index = index;
                    }
                }
                return min_index;
            }
