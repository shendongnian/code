       //beware,that we need to INIT Only once,so better to put in SplashActivity
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
