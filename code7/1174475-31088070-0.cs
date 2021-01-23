      // Creates a single instance only it it is request.
      private Output ProgressWindow
        {
          get 
              {
                  return progressWindow?? (progressWindow= new Output(){Visible = false};
              }
        }
    
       private Output progressWindow;
    
        private void button1_Click(object sender, EventArgs e)
        {            
             ProgressWindow.Visible = !ProgressWindow.Visible;
             button1.Text = (ProgressWindow.Visible) ? "Hide Progress" : "Show Progress";
                
            }
        }
