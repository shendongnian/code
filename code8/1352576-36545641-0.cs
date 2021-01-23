    public class Network
    {
        private UdpReceiver udpReceiver;
        UdpTransmitter udpTransmitter
        public event EventHandler PlayAudioEvent;
    
        public void Network()
        {
            udpReceiver.PlayAudioEvent += PlayAudioEventHandler;
    
        }
    
        void PlayAudioEventHandler(object sender, EventArgs e)
        {
            if (PlayAudioEvent != null)
            {
                PlayAudioEvent(this, null);
            }
         }
    }
    
    public class UdpReceiver
    {
         public event EventHandler PlayAudioEvent;
        void receive_audio_player_command()
        {
            if(playCommand)
                start_audio();
        }
    
        void start_audio()
        {
            //How do I call the Play_Audio() function in class Speakers
            if (PlayAudioEvent != null)
            {
                PlayAudioEvent(this, null);
            }
        }
    
    }
    
    public class Home_Media_System
    {
             
    
            public void Home_Media_System()
            {
                _networkdata.PlayAudioEvent +=  PlayAudioEventHandler
            }
    
            void PlayAudioEventHandler(object sender, EventArgs e)
            {
                _speakers.PlayAudio();
            }
