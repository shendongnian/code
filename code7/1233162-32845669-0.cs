    Timer t; 
    private void Button_Click(object sender, RoutedEventArgs e)
    {
    
        i=0;
        if(t!=null)
        { 
           t.Stop();
           t.Dispose();
        }
        t = new Timer();
        t.Interval = 800;
        t.Enabled = true;
        t.Tick += T_Tick;
        t.Start();                                                    
        
    }
    int i=0;
    private static void T_Tick(object sender, EventArgs e)
    {
       if(i<=50)
       {
            this.Top -= i; 
            this.Left -= i;
            i++;
        }
        else
         t.Stop();   
    }        
