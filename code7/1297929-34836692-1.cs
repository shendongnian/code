    public void loadFiles()
    {
       // Sets the progress bar's minimum value to a number representing
       // no operations complete -- in this case, no files read.
       progressBar1.Minimum = 0;
       // Sets the progress bar's maximum value to a number representing
       // all operations complete -- in this case, all five files read.
       progressBar1.Maximum = Convert.ToInt(lineCount); // in our case to the number of systems
       // Sets the Step property to amount to increase with each iteration.
       // In this case, it will increase by one with every file read.
       progressBar1.Step = 1;
    
       // Uses a for loop to iterate through the operations to be
       // completed. In this case, five files are to be copied into memory,
       // so the loop will execute 5 times.
       for (int i = 0; i <= 4; i++)
       {
          // Inserts code to copy a file
          progressBar1.PerformStep();
          // Updates the label to show that a file was read.
          label1.Text = "# of Files Read = " + progressBar1.Value.ToString();
       }
    }
