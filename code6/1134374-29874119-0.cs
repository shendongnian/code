    foreach (Control item in this.Controls) //Iterating all controls on form
    {
        var pb = item as PictureBox; // now you can access it a PictureBox, if it is one
        if (pb != null)
        {
            if (item.Tag.ToString() == ipAddress + "OnOff")
            {
                MethodInvoker action = delegate
                { 
                    pb.Image =  ... // works now
                }; 
                bp.BeginInvoke(action);
                break;
            }
        }
    }
