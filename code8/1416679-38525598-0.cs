    while ( isDisplayThreadRunning ) {
    
            //start a new parallel for loop
            Parallel.For( 0, numOfCamera, num => {
               BitmapSource img = bitmapQueue[i].Serve(); //Pop the frame from Queue
    
               //draw the new image on the UI thread
               Global.mainWindow.Dispatcher.Invoke(
                  new Action( delegate
                  {
                     ControlDisplay[i].DrawImage( img ); //Draw this frame on ControlDisplay[i]
                  } ) );
            } );
    
            Thread.Sleep( 50 );//sleep if desired, lowers CPU usage by limiting the max framerate
         }
    }
