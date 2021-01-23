    void checkOnClick(object obj, EventArgs ea)
    {
        tcpClient = new TcpClient("127.0.0.1", 1234);
        ns = tcpClient.GetStream();
        sr = new StreamReader(ns);
        sw = new StreamWriter(ns);
        //sending ID
        sw.WriteLine(newText.Text);
        sw.Flush();
        //receiving validity of ID
        data = sr.ReadLine();
        int validid = int.Parse(data);
        if (validid == 0)
        {            
            newText.Text="Valid data";
            check.Enabled = false;          
        }
        else
        {                        
            newText.Text="Invalid data. Please retry";       
            // Now the code will exit and your user could retry
        }
    }
