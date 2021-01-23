    using(Rtsp.RtspServer server = new Rtsp.RtspServer(555)){    
        Media.Rtsp.Server.Media.RtspSource source = 
              new Media.Rtsp.Server.Media.RtspSource("RtspSourceTest", "rtsp://1.2.3.4/mpeg4/media.amp");
                
       //If the stream had a username and password
       //source.Client.Credential = new System.Net.NetworkCredential("user", "password");
                    
       //Add the stream to the server
       server.AddMedia(source);
    
       //Start the server and underlying streams
       server.Start();
    } 
