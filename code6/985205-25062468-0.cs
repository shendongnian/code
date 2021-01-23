     private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
                Action<Datum> del = UpdateMyCollection;  
                this.BeginInvoke(del); 
    
            }
             void  UpdateMyCollection(Datum newDatum)
             {
                 _dataCollection.Add(newDatum);
             }
    
