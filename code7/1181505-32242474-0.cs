    byte[] img = File.ReadAllBytes("e:\\img.gif");
    wa.OnConnectSuccess += () =>
    {
          MessageBox.Show("Connected to whatsapp...");
    
          wa.OnLoginSuccess += (phoneNumber, data) =>
          {
              wa.SendMessage(to, msg);
    
              wa.SendMessageImage(to + "@s.whatsapp.net",img,ApiBase.ImageType.GIF);
              MessageBox.Show("Message Sent...");
          };
    }
     
