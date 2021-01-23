    private void Button1_MouseClick(object sender, MouseEventArgs e)
    {
        Size r = Button1.BackgroundImage.Size;
        // check that we have hit the image and hit a non-transparent pixel
        if ((e.X < r.Width && e.Y < r.Height) &&
                ((Bitmap)Button1.BackgroundImage).GetPixel(e.X, e.Y).A != 0)
        {
            Console.WriteLine("BUTTON clicked");  // test
            // do or call your click actions here!
        }
        // else pass the click on..
        else
        {
            // create a valid MouseEventArgs
            MouseEventArgs ee = new MouseEventArgs(e.Button, e.Clicks, 
                                    e.X + Button1.Left, e.Y + Button1.Top, e.Delta);
            // pass it on to the stuff below us
            pictureBox1_MouseClick(pictureBox1, ee);
            
            Console.WriteLine("BUTTON NOT clicked");  // test
        }
    }
