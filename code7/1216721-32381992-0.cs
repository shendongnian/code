    private void MyControl_MouseDown(object sender, MouseEventArgs e)
    {
          if (e.Clicks != 1)
          {
              IsCanDraw = false;
          }
          else
         {
             IsCanDraw = true;
         }
    
         // your other code
    
    }
