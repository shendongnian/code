            /// <summary>
            /// Check open port
            /// </summary>
            /// <param name="ser">Serial port</param>
            /// <param name="br">Baudrate</param>
            public bool CheckOpenPort(SerialPort ser, int br)
            {
                try
                {
                    if (ser.IsOpen) { ser.Close(); }
                    ser.Open();
                    ser.BaudRate = br;
                    Thread.Sleep(Op.WaitTimeOut);
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
