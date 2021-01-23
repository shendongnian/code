    public async Task ReadMessages()
    {
        while (_continue)
        {
            try
            {
                string message = await Task.Run(() => port.ReadLine());
                Console.WriteLine("message");
                pictureBox1.Invalidate();
            }
            catch (TimeoutException) {    }
        }
    }
