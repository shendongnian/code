    int _counter;
    void timer1_Tick(object sender, EventArgs e)
    {
        _counter++;
        switch(_counter)
        {
            case 1:
                _1.Visibility = Visibility.Visible;
                ...
                break;
            case 10: // do something at 10th tick
                _2.Visibility = Visibility.Visible;
                ...
                break;
            ...
        }
        // capture image from webcam
        _capture.Start() 
    }
            
