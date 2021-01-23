    public partial class HilbertDisplay : Form
        {
            private int maxDepth;
            private int xCurrent = 0;
            private int yCurrent = 0;
            private int xNew = 0;
            private int yNew = 0;
    
            public HilbertDisplay(int depthEntered)
            {
                InitializeComponent();
                maxDepth = depthEntered;
            }
    
            private void HilbertDisplay_Load(object sender, EventArgs e)
            {
                this.DoubleBuffered = true;
                this.Update();
            }
    
            // Perform the Drawing
            private void HilbertDisplay_Paint(object sender, PaintEventArgs e)
            {
                // Run the Hilbert Curve Generator
                // Use a line segment length of 10 for Y
                GenerateHilbertCurve(maxDepth, 0, 10, e);
            }
    
            // The Recursive Hilbert Curve Generator
            private void GenerateHilbertCurve(int depth, int xDistance, int yDistance, PaintEventArgs e)
            {
                if (depth < 1)
                {
                    return;
                }
                else
                {
                    GenerateHilbertCurve(depth - 1, yDistance, xDistance, e);
    
                    // Paint from the current position of X and Y to the new positions of X and Y
                    FindPointRelative(xDistance, yDistance);
                    e.Graphics.DrawLine(Pens.Red, xCurrent, yCurrent, xNew, yNew);  // Draw Part of Curve Here
                    UpdateCurrentLocation();
    
                    GenerateHilbertCurve(depth - 1, xDistance, yDistance, e);
    
                    // Paint from the current position of X and Y to the new positions of X and Y
                    FindPointRelative(yDistance, xDistance);
                    e.Graphics.DrawLine(Pens.Blue, xCurrent, yCurrent, xNew, yNew);   // Draw Part of Curve Here
                    UpdateCurrentLocation();
    
                    GenerateHilbertCurve(depth - 1, xDistance, yDistance, e);
    
                    // Paint from the current position of X and Y to the new positions of X and Y
                    FindPointRelative(-xDistance, -yDistance);
                    e.Graphics.DrawLine(Pens.Green, xCurrent, yCurrent, xNew, yNew);   // Draw Part of Curve Here
                    UpdateCurrentLocation();
    
                    GenerateHilbertCurve(depth - 1, (-1 * yDistance), (-1 * xDistance), e);
                }
            }
    
            private void FindPointRelative(int xDistance, int yDistance)
            {
                // Discover where the new X and Y points will be
                xNew = xCurrent + xDistance;
                yNew = yCurrent + yDistance;
                return;
            }
    
            private void UpdateCurrentLocation()
            {
                // Update the Current Location of X and Y
                xCurrent = xNew;
                yCurrent = yNew;
                return;
            }
        }
