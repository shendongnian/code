        private byte[] ReadBytes(int size)
        {
            //The size of the amount of bytes you want to recieve, eg 1024
            var bytes = new byte[size];
            var total = 0;
            do
            {
                var read = _connecter.Receive(bytes, total, size - total, SocketFlags.None);
                Debug.WriteLine("Client recieved {0} bytes", total);
                if (read == 0)
                {
                    //If it gets here and you received 0 bytes it means that the Socket has Disconnected gracefully (without throwing exception) so you will need to handle that here
                }
                total+=read;
                //If you have sent 1024 bytes and Receive only 512 then it wil continue to recieve in the correct index thus when total is equal to 1024 you will have recieved all the bytes
            } while (total != size);
            return bytes;
        }
