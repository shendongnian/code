    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        class ExampleProgram : Form
        {
            const int GridWidth = 24;
            const int GridHeight = 15;
            List<Point> m_points = new List<Point>();
            List<Point> m_trail = new List<Point>();
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ExampleProgram());
            }
            ExampleProgram()
            {
                // Simple little tool to add a bunch of points
                AddPoints(
                    0, 4, 1, 3, 1, 4, 1, 5, 2, 4, 2, 5, 2, 6, 3, 4, 3, 5, 4, 5, 4, 6, 5, 5, 6, 5,
                    6, 4, 5, 4, 7, 4, 7, 3, 8, 3, 8, 4, 8, 5, 8, 6, 9, 6, 9, 5, 9, 4, 9, 3, 10, 2,
                    10, 3, 10, 4, 10, 5, 10, 6, 11, 5, 11, 4, 11, 3, 11, 2, 12, 4, 12, 5, 13, 5,
                    13, 6, 13, 8, 14, 8, 14, 7, 14, 6, 15, 7, 15, 8, 15, 9, 14, 9, 14, 10, 13, 10,
                    12, 10, 11, 10, 13, 11, 14, 11, 15, 11, 15, 12, 16, 12, 17, 12, 18, 12, 19,
                    12, 18, 11, 17, 11, 17, 10, 18, 10, 19, 10, 19, 9, 19, 8, 20, 8, 21, 8, 18,
                    7, 19, 7, 20, 7, 21, 7, 21, 6, 22, 6, 23, 6, 21, 5, 20, 5, 19, 5, 19, 4, 18,
                    4, 17, 4, 20, 3, 21, 3, 22, 3, 20, 2, 19, 2, 18, 2, 19, 1, 20, 1, 21, 1, 19,
                    0, 18, 0, 10, 0, 4, 1);
                // Very basic form logic
                ClientSize = new System.Drawing.Size(GridWidth * 20, GridHeight * 20);
                DoubleBuffered = true;
                Paint += ExampleProgram_Paint;
                // Add a new point to the form (commented out)
                // MouseUp += ExampleProgram_MouseUp_AddPoint;
                // Draw the trail we find
                MouseUp += ExampleProgram_MouseUp_AddTrail;
                // Pick a starting point to start finding the trail from
                // TODO: Left as an excersize for the reader to decide how to pick
                // the starting point programatically
                m_trail.Add(new Point(0, 4));
            }
            IEnumerable<Point> Border(Point pt)
            {
                // Return all points that border a give point
                if (pt.X > 0)
                {
                    if (pt.Y > 0)
                    {
                        yield return new Point(pt.X - 1, pt.Y - 1);
                    }
                    yield return new Point(pt.X - 1, pt.Y);
                    if (pt.Y < GridHeight - 1)
                    {
                        yield return new Point(pt.X - 1, pt.Y + 1);
                    }
                }
                if (pt.Y > 0)
                {
                    yield return new Point(pt.X, pt.Y - 1);
                }
                if (pt.Y < GridHeight - 1)
                {
                    yield return new Point(pt.X, pt.Y + 1);
                }
                if (pt.X < GridWidth - 1)
                {
                    if (pt.Y > 0)
                    {
                        yield return new Point(pt.X + 1, pt.Y - 1);
                    }
                    yield return new Point(pt.X + 1, pt.Y);
                    if (pt.Y < GridHeight - 1)
                    {
                        yield return new Point(pt.X + 1, pt.Y + 1);
                    }
                }
            }
            void AddPoints(params int[] points)
            {
                // Helper to add a bunch of points to our list of points
                for (int i = 0; i < points.Length; i += 2)
                {
                    m_points.Add(new Point(points[i], points[i + 1]));
                }
            }
            void ExampleProgram_MouseUp_AddTrail(object sender, MouseEventArgs e)
            {
                // Calculate the trail
                while (true)
                {
                    // Find the best point for the next point
                    int bestCount = 0;
                    Point best = new Point();
                    // At the current end point, test all the points around it
                    foreach (var pt in Border(m_trail[m_trail.Count - 1]))
                    {
                        // And for each point, see how many points this point borders
                        int count = 0;
                        if (m_points.Contains(pt) && !m_trail.Contains(pt))
                        {
                            foreach (var test in Border(pt))
                            {
                                if (m_points.Contains(test))
                                {
                                    if (m_trail.Contains(test))
                                    {
                                        // This is a point both in the original cloud, and the current
                                        // trail, so give it a negative weight
                                        count--;
                                    }
                                    else
                                    {
                                        // We haven't visited this point, so give it a positive weight
                                        count++;
                                    }
                                }
                            }
                        }
                        if (count > bestCount)
                        {
                            // This point looks better than anything we've found, so 
                            // it's the best one so far
                            bestCount = count;
                            best = pt;
                        }
                    }
                    if (bestCount <= 0)
                    {
                        // We either didn't find anything, or what we did find was bad, so
                        // break out of the loop, we're done
                        break;
                    }
                    m_trail.Add(best);
                }
                Invalidate();
            }
            void ExampleProgram_MouseUp_AddPoint(object sender, MouseEventArgs e)
            {
                // Just add the point, and dump it out
                int x = (int)Math.Round((((double)e.X) - 10.0) / 20.0, 0);
                int y = (int)Math.Round((((double)e.Y) - 10.0) / 20.0, 0);
                m_points.Add(new Point(x, y));
                Debug.WriteLine("m_points.Add(new Point(" + x + ", " + y + "));");
                Invalidate();
            }
            void ExampleProgram_Paint(object sender, PaintEventArgs e)
            {
                // Simple drawing, just draw a grid, and the points
                e.Graphics.Clear(Color.White);
                for (int x = 0; x < GridWidth; x++)
                {
                    e.Graphics.DrawLine(Pens.Black, x * 20 + 10, 0, x * 20 + 10, ClientSize.Height);
                }
                for (int y = 0; y < GridHeight; y++)
                {
                    e.Graphics.DrawLine(Pens.Black, 0, y * 20 + 10, ClientSize.Width, y * 20 + 10);
                }
                foreach (var pt in m_points)
                {
                    e.Graphics.FillEllipse(Brushes.Black, (pt.X * 20 + 10) - 5, (pt.Y * 20 + 10) - 5, 10, 10);
                }
                foreach (var pt in m_trail)
                {
                    e.Graphics.FillEllipse(Brushes.Red, (pt.X * 20 + 10) - 6, (pt.Y * 20 + 10) - 6, 12, 12);
                }
            }
        }
    }
