    public partial class formOpConfig : Form
    {
        public event EventHandler UpdateData;
        private void SomethingHappens()
        {
            // do stuff...
            OnUpdateData();
            // maybe do other stuff too...
        }
        private void OnUpdateData()
        {
            EventHandler handler = UpdateData;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
