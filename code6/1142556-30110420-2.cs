    public class BTimer : IDisposable
    {
    private string theTime;
    private Timer timer; 
     
     ........     
     
    void Dispose()
    {
        timer.Stop();
         timer.Dispose();
    }
