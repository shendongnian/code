        private void mListener_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            if (isDown)
            {
                isDown = false;                    
                Console.Out.WriteLine(count);
                sim.Mouse.LeftButtonUp(); //maybe try this
            }
            else
            {
                Console.Out.WriteLine(count);
                isDown = true;
                sim.Mouse.LeftButtonDown();
            }
        }
    }
