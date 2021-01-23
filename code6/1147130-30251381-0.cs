    DateTime aMoment = DateTime.Now;
    SerialPort aPort = (SerialPort)sender;
    string indata = aPort.ReadLine(); <<<-- Read data before invoke.
    // Because I am updating the UI from a thread other than the main thread.
    this.Dispatcher.Invoke((Action)((indata ) =>
    {
        string outData = aMoment.ToString("yyyy-MM-dd, HH':'mm':'ss.fff, ") + indata + Environment.NewLine;
        if (chkEnableDatalog.IsChecked == true)
            File.AppendAllText(@txtDatalogPath.Text, outData);
        txtSerialIn.Text = indata;
        txtDataLogLine.Text = outData;
        txtSerialOutHistory.AppendText("<" + indata);
        outData = "";
        indata = "";
    }));
}
