           public void LongProcess()
           {
                Thread t = new Thread(new ThreadStart(
                delegate
                   {
                      
                    //Complex code goes here
                   this.Dispatcher.Invoke((Action)(() =>
                   {
                      //Any requests for controls or variables that you need
                      //from the main application running on the main dispatcher
                      //goes here
                   }));
                    
                    //Finally once you've got the information to return to
                    //your user call a message box here and populate the 
                    //message accordingly.
                    MessageBox.Show("", "");
                    //If a message box fails or isn't good enough
                    //create your own user control and call it here like:
                    usrConMessage msg = new usrConMessage();
                    msg.strTitle = "Whatever";
                    msg.strContent = "Whatever";
                    msg.show(); //Not a dialog so doesn't steal focus
                    //That is normally how I would go about providing a
                    //unique and polished user experience.
       
                   }
                 ));
                t.Start();
          }
