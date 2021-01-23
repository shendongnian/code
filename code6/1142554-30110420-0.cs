    class Cellules : IDisposable
    {
       BTimer timer // disposable member
       public void Dispose() // implementing IDisposable
       {
            timer.Dispose();
       }
    }
