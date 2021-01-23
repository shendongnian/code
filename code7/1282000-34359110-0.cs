    public class SubForm : Form
    {
        // this is the event to register with from MainForm
        public event EventHandler ButtonClicked;
        // thread safe event invocator (standard pattern)
        protected virtual void OnButtonClicked()
        {
            EventHandler handler = ButtonClicked;
            if (handler != null) handler(this, EventArgs.Empty);
        }
       
        // your button handler
        private void button1_Clicked(object sender, Eventargs e)
        {
            OnButtonClicked();
        }
    }
