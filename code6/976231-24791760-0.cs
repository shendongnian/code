    public void ScanEvent()
    {
        string strBarcode = scanner.strBarcode;
        Application.Current.Dispatcher.Invoke(
            new Action(() => MyList.Insert(0, strBarcode)));
    }
