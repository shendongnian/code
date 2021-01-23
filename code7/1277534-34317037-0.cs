    class PeakClass
    {
        static int CurrentProcessID = 0000;
        private static void Main(string[] args)
        {
            //Basically gets your default audio device and session attached to it
            using (var sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render))
            {
                using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
                {
                    //This will go through a list of all processes uses the device
                    //the code got two line above.
                    foreach (var session in sessionEnumerator)
                    {
                        //This block of code will get the peak value(value needed for VU Meter)
                        //For whatever process you need it for (I believe you can also check by name
                        //but I found that less reliable)
                        using (var session2 = session.QueryInterface<AudioSessionControl2>())
                        {
                            if(session2.ProcessID == CurrentProcessID)
                            {
                                using (var audioMeterInformation = session.QueryInterface<AudioMeterInformation>())
                                {
                                    Console.WriteLine(audioMeterInformation.GetPeakValue());
                                }
                            }
                        }
                       //Uncomment this block of code if you need the peak values 
                       //of all the processes
                       //
                        //using (var audioMeterInformation = session.QueryInterface<AudioMeterInformation>())
                        //{
                        //    Console.WriteLine(audioMeterInformation.GetPeakValue());
                        //}
                    }
                }
            }
        }
        private static AudioSessionManager2 GetDefaultAudioSessionManager2(DataFlow dataFlow)
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                using (var device = enumerator.GetDefaultAudioEndpoint(dataFlow, Role.Multimedia))
                {
                    Console.WriteLine("DefaultDevice: " + device.FriendlyName);
                    var sessionManager = AudioSessionManager2.FromMMDevice(device);
                    return sessionManager;
                }
            }
        }
    }
