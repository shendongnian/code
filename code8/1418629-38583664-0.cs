    string data = "keepForever = true";
    WebClient client = new WebClient();
    client.Encoding = System.Text.Encoding.UTF8;
    string reply = client.UploadData(url, "PATCH", System.Text.Encoding.UTF8.GetBytes(data));
    Console.WriteLine(reply);
