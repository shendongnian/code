    CustomTraceListener myTraceListener = new CustomTraceListener();
    Debug.Listeners.Add(myTraceListener);
    Debug.WriteLine("this is a test");
    Debug.WriteLine("this is another test");
    string result = myTraceListener.ToString();
