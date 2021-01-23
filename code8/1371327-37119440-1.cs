    //somewhere, like in the forms constructor, you need to subscribe to this event
    watermarkedTextbox2.PropertyChanged += watermarkedTextbox2_PropertyChanged;
    // the handler function
    void watermarkedTextbox2_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsWaterMarked")
        {
            if (watermarkedTextbox2.IsWaterMarked)
                ; //handle here
            else
                ; //handle here
        }
    }
