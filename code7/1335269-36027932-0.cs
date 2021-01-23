    class Radio
    {
        private int radioChannel;
        //Your code here
        public void TurnOnRadio(RemoteControl Remote)
        {
            Remote.channelChange = new RemoteControl.ChannelChanged(RadioChannelChanged);
            //Console.WriteLine(Remote.ToString() + " is deteceted");
        }
        public void RadioChannelChanged(object Remote,RemoteEventsArgs re)
        {
            radioChannel = re.newChannel;
            Console.WriteLine("Radio channel is changed. New channel is :{0}", re.newChannel);
        }
        //May need to write RadioChannelChanged method
        
    }
