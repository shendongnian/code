    public  MainActivity()
            {
                if (!OpenCVLoader.InitDebug())
                {
                    System.Console.WriteLine("Failed to INIT \n OpenCV Failure");
                }
                else
                {
                    System.Console.WriteLine("OpenCV INIT Succes");
                }
            }
