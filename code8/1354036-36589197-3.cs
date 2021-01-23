            private bool ArduinoDetected()
        {
            try
            {
                currentPort.Open();
                System.Threading.Thread.Sleep(1000); 
                string returnMessage = currentPort.ReadLine();
                currentPort.Close();
                if (returnMessage.Contains("Info from Arduino"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
