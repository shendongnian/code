    public class DispCombo : ComboBox, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
    public class DispGrid : Grid, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
