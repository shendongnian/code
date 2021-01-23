    private bool run = true; //set this to false when your program closes
    private void StartPollPixel(Point location, Color color)
    {
        Task.Factory.StartNew( () => {
        
           while( run )
           {
               var c = GetColorAt(location);
    
               if (c.R == color.R && c.G == color.G && c.B == color.B)
               {
                   DoAction(); //if you manipulate the UI do not forget to Invoke()
                   Thread.Sleep(1000);
               }
           }
    
        });
    
    }
