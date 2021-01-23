    try 
    {
        await Task.Delay(new TimeSpan(0, 0, 2)).ConfigureAwait(false);
    }
    catch (System.Threading.Tasks.TaskCanceledException ex)
    {
        MessageBox.Show(ex.Message);
    }
