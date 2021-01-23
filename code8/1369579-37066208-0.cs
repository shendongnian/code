    //First, get rid if the 'static' you need the 
    //instance of your window or whatever to access textBox1
    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();           
        SetOutput(indata);   
    }
    private void SetOutput(string data)
    {
        //CheckAccess is a hidden Method, it might not me visible in Intellisense / AutoComplete
        if(textBox1.CheckAccess())
        {
            //textBox1 is directly accessible
            textBox1.Text = data;
        }
        else
        {
            //Dispatcher call needed
            textBox1.Dispatcher.BeginInvoke(
                    new Action(() =>
                    {
                        SetOut(data);
                    })
                );
        }
    }
