    public class MyWindow : Window
        {
            void StartButton_Click( object sender, RoutedEventArgs e )
            {
                // This method will run on the UI thread
    
                BackgroundWorker worker = new BackgroundWorker();
    
                worker.DoWork += worker_DoWork;
                worker.WorkerReportsProgress = true;
                worker.ProgressChanged += worker_ProgressChanged;
    
                worker.RunWorkerAsync(); // start the thread
    
                // UI thread continues immediately
    
                // exit click event handler, UI thread goes back to WPF control so it can keep rendering...
            }
    
            void worker_ProgressChanged( object sender, ProgressChangedEventArgs e )
            {
                // This method will run on the UI thread
    
                double depth_max = (double) e.UserState; // grab the value of depth_max passed over from background thread
    
                depth_max_slider.Value = depth_max; // update the slider with this value
    
                // exit ProgressChanged event handler, UI thread goes back to WPF control so it can keep rendering...
            }
    
            void worker_DoWork( object sender, DoWorkEventArgs e )
            {
                // This method will run on the background thread
    
                BackgroundWorker worker = sender as BackgroundWorker;
    
                int percentComplete = 0;
                double depth_max;
    
                while( depthScan == true )
                {
                    depth_max += 10; // NOTE: don't touch the slider control from the background thread, use a double instead!
    
                    worker.ReportProgress( percentComplete, depth_max ); // pass depth_max as the 2nd param, "user state", will show up in ProgressChangedEventArgs in ProgressChanged handler
    
                    Console.WriteLine( "Working" );
                    if( blobCount <= 400 )
                    {
                        depth_max += 10;
    
                        worker.ReportProgress( percentComplete, depth_max );
    
                    }
                    else
                    {
                        depthScan = false;
                    }
    
                }
            }
        }
