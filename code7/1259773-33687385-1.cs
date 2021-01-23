        private async void btnDoWhileLoop_Click(object sender, EventArgs e)
        {
            int r = 0; //row
            int c = 0; //column
            int intResult;
            string strSpace;
            txtTable.Clear();       //clear the text box
            await Task.Delay(1000); //wait one second to see the clear text box
            txtTable.AppendText("\r\n");
            // set up a helper to make it easy to update the UI from the background
            // task Non-standard event arg type of "string", because we don't need
            // anything fancier
            Progress<string> progress = new Progress<string>();
            // This event is raised when progress.Report() is called (see below)
            progress.ProgressChanged += (sender, e) =>
            {
                txtTable.AppendText(e);
            };
            // Wrap the loops in an anonymous method (i.e. the () => { ... } syntax)
            // and pass that to Task.Run() so it can run as a background task
            await Task.Run(() =>
            {
            //Outer loop goes down the rows
            //initialize r
            //do
            //Inner loop goes across the columns
            //initialize c
            //do
            for (r = 1; r < 10; r++)
            {
                for (c = 1; c < 10; c++)
                {
                    intResult = r * c;
                    if (intResult < 10)
                        strSpace = "  ";  //two spaces 
                    else
                        strSpace = " ";   //one space
                    // While the task is running in a thread other than your original
                    // UI thread, using the "progress" object here allows the task to pass
                    // data back to the UI thread where it is allowed to call e.g.
                    // txtTable.AppendText() to update the UI.
                    progress.Report(strSpace); // insert space
                    progress.Report(intResult.ToString());  //insert result
                }
                // I think you wanted this line outside the inner loop
                progress.Report("\r\n");  //Move down one line
            }
            });
            // There's nothing else to do. But if you wanted to you could add code here
            // to do something after the task is run. Using "await" allows the UI thread
            // to keep running while the task is running, and then return control to
            // this method here when it's done.
        }
