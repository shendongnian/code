        // Connect to the host using its IPEndPoint.
        s.Connect(hostEndPoint);
        if (!s.Connected)
        {
          // Connection failed, try next IPaddress.
          strRetPage = "Unable to connect to host";
          s = null;
          continue;
        }
