    private void pnSearch_MouseHover(object sender, EventArgs e)
        {
            ReshapePanel(pnSearch);
        }
        private void ReshapePanel(Panel p)
        {
            int targetSize;
            int threshold;
            int changeDelay = 8000;
            decimal direction;
            if (p.Width == 0)
            {   //Expand
                targetSize = 200;
                threshold = 195;
                direction = 1;
            }
            else
            {   //Contract
                targetSize = 1;
                threshold = 5;
                direction = 2;
            }
            do
            {
                if (pnSearch.Width > threshold)
                {
                    pnSearch.Width = targetSize;
                }
                else
                {
                    if (direction == 2)
                    {
                        pnSearch.Width = pnSearch.Width + 1;
                    }
                    else
                    {
                        pnSearch.Width = pnSearch.Width - 1;
                    }
                    //pnSearch.Width = pnSearch.Width + parse.int(1 * direction);
                    Task.Delay(changeDelay);
                }
            } while (pnSearch.Width != targetSize);
        }
 
