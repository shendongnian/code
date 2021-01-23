    private void timer_Tick(object sender, EventArgs e)
    {
        if (serialPort != null && serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            data_as_string += serialPort.ReadLine();
        }
    }
