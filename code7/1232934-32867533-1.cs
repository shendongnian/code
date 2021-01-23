    string postData = "value1=" + 1 + "&value2=" + 2 + "&value3=" + 3;
    System.Text.Encoding encoding = System.Text.Encoding.UTF8;
    byte[] bytes = encoding.GetBytes(postData);
    string url = "http://www.domain.com/addSomething";
    webBrowser1.Navigate(url, string.Empty, bytes, "Content-Type: application/x-www-form-urlencoded"); 
