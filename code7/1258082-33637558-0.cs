    //Create a delegate for the call 
    public delegate void VoidStringDelegate(string str);
    
    public void UpdateLabel12(string LabelText)
    {
        if (!label12.InvokeRequired)
        {//If on the same thread directly change the value
            label12.Text = LabelText;
        }
        else
        {//If on a separate thread make an invoke call to this method from the correct thread
            label12.Invoke(new VoidStringDelegate(UpdateLabel12), LabelText);
        }
    }
