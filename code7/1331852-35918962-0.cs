    static void ThreadSafeMessageBox(String text)
    {
      Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(text)));
    }
    void Test()
    {
      Task.Run(() => { ThreadSafeMessageBox("Hi!");});
    }
