    private void form_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Up:
                // do your up arrow thing here...
                break;
            case Keys.Down:
                if (e.Control)
                {
                    // get fancy if the control key + down arrow is pressed 
                    // at the same time
                }
                else
                {
                    // do the normal down arrow stuff
                }
                break;
        }
    }
