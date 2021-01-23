    private void GetMessageThread()
         {
             bool receive = true;
             Stream strm = client.GetStream();
             while (receive)
             {
                 try
                 {
                    IFormatter formatter = new BinaryFormatter();
                    string obj;
                    if (strm.CanRead)
                    {
                        obj = (string)formatter.Deserialize(strm);
                    }
                    else
                    {
                        _receive = false;
                        break;
                    }
               }
             }
        }
