        //declare variables
        public const int offset = 50;
        public const int boardX = 10;
        public const int boardY = 10;
        public const int checkSize = 40;
        int[] checks;
        //set initial values for the checks array
        if(checks == null)
        {
            checks = new int[boardX * boardY];
        }
        
        //start iterating through the array of checks
        for (int i = 0; i < checks.Length; i++)
        {
            //if the check is empty (assuming you will use integers as identifiers for the pieces on the board)
            if (checks[i] < 1)
            {
                //check if the check in array is odd number & paint odd numbers black on alternating rows
                if (i % 2 != 0)
                {
                    //check if row is odd
                    if (Math.Ceiling((double)(i + 1) / boardX) % 2 != 0)
                    {
                        drawCheck(Brushes.Black, e.Graphics, i);
                    }
                    else
                    {
                        drawCheck(Brushes.White, e.Graphics, i)
                    }
                }
                else
                {
                    //check if row is odd
                    if (Math.Ceiling((double)(i+1) / boardX) % 2 != 0;
                    {
                        drawCheck(Brushes.White, e.Graphics, i);
                    }
                    else
                    {
                        drawCheck(Brushes.Black, e.Graphics, i)
                    }
                }
            }
            else if (checks[i] == 1)
            {
                //the check is a "clicked check" - draw it red
                drawCheck(Brushes.Red, e.Graphics, i);
            }
        }
        //The Methods
        private void YOURDRAWINGSURFACE_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.X < (boardX * checkSize) + offset && e.Y < (boardY * checkSize) + offset && e.X > offset && e.Y > offset )
            {
                //you have clicked somewhere on the board. if that square isn't red, make it so, else turn it back to a normal square
                if (checks[checkClicked(e.X, e.Y)] != 1)
                {
                    checks[checkClicked(e.X, e.Y)] = 1;
                }
                else
                {
                    checks[checkClicked(e.X, e.Y)] = 0;
                }
            }
            //this is only relevant for GDI drawing code. It will invalidate the form to redraw the surface (needs to be called whenever you make a change)
            this.Invalidate();
        }
        public int checkClicked(int mouseX, int mouseY)
        {
            //this method returns the int of the particular check that was clicked in the array.
            return ((int)Math.Ceiling((double)(mouseX - offset) / checkSize) + (int)((Math.Ceiling((double)(mouseY - offset) / checkSize)) * boardX) - (1 + boardX));
        }
        public void drawCheck(Brush brush, Graphics graphics, int checkNumber)
        {
            //this method draws the check given the parameters.
            graphics.FillRectangle(brush, ((checkNumber % boardX) * checkSize) + offset, (int)(Math.Ceiling((double)(checkNumber-(boardX-1)) / boardX) * checkSize) + offset, checkSize, checkSize);
        }
