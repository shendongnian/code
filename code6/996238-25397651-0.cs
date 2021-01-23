    public class Stream : IDisposable {
        IDisposable.Dispose(){
            Close();
        }
        public void Close(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
