    private async void bConnect_Click(object sender, EventArgs e)
    {
        string strAddress = "http://localhost:9003/CalculatorService";
        BasicHttpBinding httpBinding = new BasicHttpBinding();
        EndpointAddress address = new EndpointAddress(strAddress);
        ChannelFactory<ICalculatorService> channel = new ChannelFactory<ICalculatorService>(httpBinding, address);
        var game = channel.CreateChannel(address);
        string num = 
            await Task.Factory.FromAsync<int, int, string> (
                game.BeginGetSum,
                game.EndGetSum,
                4, 1,
                null);
        Debug.Write(num);
    }
