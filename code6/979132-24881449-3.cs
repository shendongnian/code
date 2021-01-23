    public class <TheCallingClassOutsideDLL>
    {
        private <TheClassInDLL> myClass;
        public TheCallingClassOutsideDLL()
        {
            myClass = new TheClassInDLL();
            myClass.DataEventCalled += DataEvent;
        }
        private void DataEvent(object sender, <TheClassInDLL>.MyEventArgs e)
        {
            Console.WriteLine(e.Response);
        }
    }
