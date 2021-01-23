      public class BaseLoaderHelper : BaseLoaderCallback
        {
            public BaseLoaderHelper(Context context):base(context)
            {
            }
        }
    
            BaseLoaderCallback _t = new BaseLoaderHelper(this);
    if(OpenCVLoader.InitAsync(OpenCVLoader.OpencvVersion3000,this,_t))
                        {
                        System.Console.WriteLine("OK");
                        }
                }   
 
