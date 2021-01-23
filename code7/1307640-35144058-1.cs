    public bool Read_Board_Port()
        {
            byte[] bData = new byte[256];
            string message;
            bool sucess = false;
            try
            {
                if (!(serialBoardPort.IsOpen == true))
                    Connect_To_Board(Globals.BoardportName, Globals.BoardbaudRate, Globals.Boardparity, Globals.BoardstopBits, Globals.BoarddataBits);
    
               if(CMDDirect || Globals.HostCommandString)
                {
                    serialBoardPort.ReadTimeout = 1000; // Timeout if no answer from the port.
                    message = serialBoardPort.ReadLine();
                    Globals.RXBoardBuff = Encoding.UTF8.GetBytes(message);
                    Write_To_Console_Dr(message);
                    sucess = true;
                }
               else
                {
                    serialBoardPort.Read(Globals.RXBoardBuff, 0, Constants.RXBOARDBUFFSIZE);
                    if (Check_Command_Correct(Globals.RXBoardBuff, Globals.CommandOut))
                        sucess = true;
                    else
                    {
                        Write_Error_To_Console_Dr(Constants.ERRORDATAFROMBOARDPORT);
                        sucess = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show(Constants.ERRORNODATABOARPORT);
                sucess = false;
            }
    
            return sucess;
        }
    
    // since serialBoardPort seems to be a globally declared variable
    public SerialPort GetInstance()
    {
    	return serialBoardPort;
    }
    
    // Let's name your class as board..
    // on somewhere in your app code:
    
    Board board = // GetValue 
    SerialPort boardSerialPort = board.GetInstance();
    
    ClassXXX.StaticMethodNeedsPort(boardSerialPort); // pass your serial port to the static method
