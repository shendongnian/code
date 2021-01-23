            VlcControl vlc = new VlcControl();
            //LocationMedia media = new LocationMedia(@"C:\Users\pgu001\Downloads\Storage_Shipping_Container_Tilt_Bed_Trailer_Delive.avi");
            
            //Vlc.DotNet.Core.Medias.MediaBase media1 = new Vlc.DotNet.Core.Medias.PathMedia("rtsp://admin:admin@172.16.22.61:554/live.");
            //media.AddOption(":sout=#transcode{vcodec=theo,vb=800,scale=1,acodec=flac,ab=128,channels=2,samplerate=44100}:std{access=file,mux=ogg,dst=D:\\123.mp4}");
            panel1.Controls.Add(vlc);
            vlc.BackColor = System.Drawing.Color.Black;
            vlc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            vlc.Location = new System.Drawing.Point(0, 0);
            vlc.Name = "test";
            vlc.Rate = 0.0F;
            vlc.Size = new System.Drawing.Size(panel1.Width, panel1.Height);
            //Vlc.DotNet.Core.Medias.MediaBase media = new Vlc.DotNet.Core.Medias.PathMedia(@"rtsp://172.16.22.61:554/live.sdp");
            LocationMedia media = new LocationMedia(@"rtsp://172.16.22.61:554/live");
            vlc.Media = media;
            vlc.Play();
