    DateTime rfidConnectedTime; 
    private void rfid_ConnectionChanged(object sender RFIDEventArgs e){ //this is a hypothetical event handler
        if(e.IsConnected){
            rfidConnectedTime = DateTime.Now;
            timer1.Start();
        } else {
            timer1.Stop();
        }
    }
