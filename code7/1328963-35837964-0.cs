    public void ImgRecive()
        {
            tcp.Start();
            sock = tcp.AcceptSocket();
            ns = new NetworkStream(sock);
            while (sock.Connected == true)
            {
                try
                {
                    tcp.Start();
                    sock = tcp.AcceptSocket();
                    ns = new NetworkStream(sock);
                    pictureBox1.Image = Image.FromStream(ns);
                    tcp.Stop();
                    ns.Flush();
                }
                catch (Exception exxx) { MessageBox.Show(exxx.Message); }
            }
        }
