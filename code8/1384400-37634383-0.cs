    HashSet<string> textHistory = new HashSet<string>();
    // ....
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    bufferText = (string)iData.GetData(DataFormats.Text);      // Clipboard text
                    if (bufferText != "") {
                        textHistory.Add(bufferText);
                        ClipboardHistory.Text = String.Join(Environment.NewLine, textHistory);
                    }
                }
     
