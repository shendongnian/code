    private async void BtnXmlWrite_Click(object sender, RoutedEventArgs e)
    {
        String input1value = TxtInput.Text;
        if (null != input1value && "" != input1value)
        {
            var value = doc.CreateTextNode(input1value);
            //find input1 tag in header where id=1
            var xpath = "//header[@id='1']/user_input/input1";
            var input1nodes = doc.SelectNodes(xpath);
            for (uint index = 0; index < input1nodes.Length; index++)
            {
                input1nodes.Item(index).AppendChild(value);
            }
            RichEditBoxSetMsg(ShowXMLResult, doc.GetXml(), true);    
        }
        else
        {
            await new Windows.UI.Popups.MessageDialog("Please type in content in the  box firstly.").ShowAsync();
        }
    }
    
