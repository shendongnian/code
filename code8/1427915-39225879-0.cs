             {
                ...  
                //Get document container
                var document = _modalWindow.Get(SearchCriteria.ByAutomationId(Config.DocumentRulesEvent));
                
                // Get document's bounding Rectangle
                string rightCorner = document.Bounds.Right.ToString();
                string leftCorner = document.Bounds.Left.ToString();
                string topCorner = document.Bounds.Top.ToString();
                string bottomCorner = document.Bounds.Bottom.ToString();
                // Hardcoded percent of x and y
                int percentX = 22;
                int percentY = 7;
                
                
                GetCoordinatesFromBoundingRectangle(rightCorner, leftCorner, topCorner, bottomCorner, percentX, percentY);
            }
            
    		public void GetCoordinatesFromBoundingRectangle(string rightCorner, string leftCorner, string topCorner, string bottomCorner, int percentX, int percentY)
            {
                
                // transform strings to integre    
                int a = Int32.Parse(rightCorner);
                int b = Int32.Parse(leftCorner);
                int c = Int32.Parse(topCorner);
                int d = Int32.Parse(bottomCorner);
    
                // Calculate X from AB segment
                int x = (a - b) * percentX;
                x = x / 100;
                x = b + x;
                
                //Calculate Y from CD segment
                int y = (d - c) * percentY;
                y = y / 100;
                y = c + y;
                
                ClickOnPoint(x, y);
                
    
            }
 
            // Method that moves mouse to x and y and click
            public void ClickOnPoint(int x, int y)
            {
                var pointClick = new System.Windows.Point(x, y);
                Mouse.Instance.Click(MouseButton.Left, pointClick);
            }
