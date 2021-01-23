    public SolidColorBrush BackGroundColor {get;set;}
    
    public void ChangeColor()
    {
       MessageBox.Show("Color before: " + MainCanvas.Background.ToString());
    
       Random rnd = new Random();
       int i = rnd.Next(_listOfColors.Count - 1);
       BackGroundColor = new SolidColorBrush(_listOfColors[i]);
    
       MessageBox.Show("Color after: " + MainCanvas.Background.ToString());
    }  
