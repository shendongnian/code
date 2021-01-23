                //...                
                try
                { RS485Port.Close(); }
                catch
                { }
                RS485Port = new System.IO.Ports.SerialPort(allComPorts[(int)cmbRS485Port.Value - 1]);
                if (!RS485Port.IsOpen)
                {
                   // RS485Port.Close();
                   // RS485Port = new System.IO.Ports.SerialPort(allComPorts[(int)cmbRS485Port.Value - 1]);
                    RS485Port.BaudRate = 9600;
                    RS485Port.Parity = System.IO.Ports.Parity.None;          
                    RS485Port.StopBits = System.IO.Ports.StopBits.One;    
                    RS485Port.DataBits = 8;                                      
                    RS485Port.Handshake = System.IO.Ports.Handshake.None;      
                    RS485Port.RtsEnable = true;
                    RS485Port.Open();
                }
