    private void button2_Click(object sender, RoutedEventArgs e)
    {
        dynamic doc = webBrowser1.Document;
        dynamic input = doc.getElementsByTagName("input");
        foreach (dynamic element in input)
        {
            if (element.getAttribute("name") == "username")
            {
                element.setAttribute("value", "someString");
                break;
            }
        }
    }
