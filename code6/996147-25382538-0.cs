    private void timer1_Tick(object sender, EventArgs e)
        {
            if(timeLeft > 0) {
                timeLeft = timeLeft - 1;
            }
            if(timeLeft = 0 && !hasCompleted)
            {
                timer1.Stop();
                webBrowser1.Stop();
            }
            else{
                timer1.Stop();
            }
        }
      private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
       {
            hasCompleted = true;
            //your code
    }
    
     
