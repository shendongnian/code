    MMDevice VUDevice;
    
    public void SetVolume(float vol)
        {
            if(vol > 0)
            {
                VUDevice.AudioEndpointVolume.Mute = false;
                VUDevice.AudioEndpointVolume.MasterVolumeLevelScalar = vol;
            }
            else
            {
                VUDevice.AudioEndpointVolume.Mute = true;
            }
            Console.WriteLine(vol);
        }
