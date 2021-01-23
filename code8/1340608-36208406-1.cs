    public double Zoom
            {
                get { return zoom; }
                set 
                {
                    if (value != zoom)
                    {
                        zoom = value;
                        RaisePropertyChanged("Zoom");
                        RaisePropertyChanged("CanvasH");
                        RaisePropertyChanged("CanvasW");
                        RaisePropertyChanged("TransX");
                        RaisePropertyChanged("TransY");
                    }
                }
            }
    
    public double TransX
            {
                get 
                {
                    if (imageSource != null)
                    {
                        return ((imageSource.Width *zoom - imageSource.Width)/2;
                    }
                    return 0;
                }
            }
    
    public double TransY
            {
                get
                {
                    if (imageSource != null)
                    {
                        return (imageSource.Height * zoom - imageSource.Height) / 2;
                    }
                    return 0;
                }
            }
    public double CanvasH
            {
                get 
                {
                    if (imageSource!=null)
                    {
                        return imageSource.Height*zoom;
                    }
                    return canvasH;
                }
    }
    public double CanvasW
            {
                get
                {
                    if (imageSource != null)
                    {
                        return imageSource.Width*zoom;
                    }
                    return canvasW;
                }
 
