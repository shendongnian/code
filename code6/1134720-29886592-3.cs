    private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            // read the response.
            var response = ((SerialPort)sender).ReadLine();
            // Need to update the txtMessage on the UI thread.
            this.Invoke(new Action(() => txtMessage.Text = response));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
