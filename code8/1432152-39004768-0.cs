    for (int i = 0; i < 10; i++)
            {
                const string path = @"[path].xml";
                try
                {
                    // After the first exception, this call will start throwing
                    // an exception to the effect that the file is in use
                    StreamWriter sWrite = new StreamWriter(path, true);
               
                    // The first time I run this exception will be raised
                    throw new Exception();
                    // Close will never get called and now I'll get an exception saying that the file is still in use
                    // when I try to open it again. That's because the file lock was never released due to the exception
                    sWrite.Close();
                }
                catch (Exception e)
                {
                }
                    //LOTS OF SWRITE LINES HERE
                Process.Start(path);
            }
