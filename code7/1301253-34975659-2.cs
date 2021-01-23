    void processKey(Keys key)
    {
        // check timing (keystrokes within 100 ms)
        TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
        if (elapsed.TotalMilliseconds > 100)
            _barcode = ""; // Clear();
        // record keystroke & timestamp
        _barcode += ((char)key); // e.KeyChar);
        _lastKeystroke = DateTime.Now;
        // process barcode
        if (key == Keys.Enter)// == 13 && _barcode.Length > 0)
        {
            string msg = new String(_barcode.ToArray());
            if (BarCodeScanned != null)
            {
                BarCodeScanned(sender, 
                               new BarcodeScannedEventArgs(new String(_barcode.ToArray())));
            }
            BarCodeScanned(_barcode);
            _barcode .Clear();
        }
    }
