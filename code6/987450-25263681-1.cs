    private void Reconnect()
    {
        for (int i = 0; i < connections.Length; ++i)
        {
            if (!IsAvailable(this.connections[i]))
            {
                this.ReconnectAt(i);
            }
        }
    }
    private void ReconnectAt(int index)
    {
        try
        {
            this.connections[index] = new MySqlConnection(this.connectionString);
            this.connections[index].Open();
        }
        catch (MySqlException mse)
        {
            Console.WriteLine("Reconnect error: " + mse.Message);
            this.connections[index] = null;
        }
    }
