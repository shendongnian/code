           ILoaderCallbackInterface t = new LoaderCallBackHelper();
     public  MainActivity()
            {
                if(OpenCVLoader.InitAsync(OpenCVLoader.OpencvVersion3000,this,t))
                    {
                    System.Console.WriteLine("OK");
                    }
            }  
