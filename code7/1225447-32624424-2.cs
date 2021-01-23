    [DataContract]
    public class TPropHatchBrush : IDisposable
    {
        System.Windows.Input.Cursor cursor;
        [DataMember]
        public System.Windows.Input.Cursor Cursor { get { return cursor; } set { cursor = value; } }
        #region IDisposable Members
        public void Dispose()
        {
            var oldCursor = Interlocked.Exchange(ref this.cursor, null);
            if (oldCursor != null)
                oldCursor.Dispose();
        }
        #endregion
    }
