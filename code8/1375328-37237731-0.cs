      private void timer1_Tick(object sender, EventArgs e)
            {
                x += xmove;             // add 10 to x and y positions
                y += ymove;       
                if(y + 30 >= pbxDisplay.Height)
                {
                    ymove = -ymove;
                }
                if (x + 30 >= pbxDisplay.Width)
                {
                    xmove = -xmove;
                }
                if (x - 30 <= 0)
                {
                    xmove = -xmove;
                }
                if (y - 30 <= 0)
                {
                    ymove = -ymove;
                }
                Refresh();              // refresh the`screen .. calling Paint() again
    
            }
