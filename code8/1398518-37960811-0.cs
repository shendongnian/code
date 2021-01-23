    private void AtlasCompleted(object sender, AsyncCompletedEventArgs e)
    {
    if(e.Error !=null)
        Console.WriteLine(e.Error.Message);
         else
       Console.WriteLine("Completed");
    
        MessageBox.Show(Beta.ToString() + "               " + FormPopup.Variables.Location1);
    }
     
