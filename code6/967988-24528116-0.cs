          timer1.Enabled=true;
          timer1.Interval=1000;
          int count=0;
        private void timer1_tick(object sender,Eventargs e)
        {
        if(System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()==false)
        {
        count++;
        }
        }
        
