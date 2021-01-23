     private SerialPort port;
                StringBuilder SB;
                private void Recepcion(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
                {
                    try
                    {
                        SB = new StringBuilder(1000);
                        SB.Append(port.ReadLine());
                        port.DiscardInBuffer();
                        this.Invoke(new EventHandler(Actualizar));
                    }
                    catch { }
                }
