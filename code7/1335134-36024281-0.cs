    public void handlerThread()
        {
          
                byte[] rx = new byte[1024];
                Socket hanso = (Socket)alSockets[alSockets.Count - 1];
                while (true)
                {
                NetworkStream ns = new NetworkStream(hanso);
                ns.Read(rx, 0, rx.Length);
                string str = Encoding.ASCII.GetString(rx);
                this.Invoke(new UpdateLogCallback(this.update), new object[] { str });
               
            }
            
        }
