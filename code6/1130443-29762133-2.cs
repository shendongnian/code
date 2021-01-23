    public class PCM1_Setup : IGUI_to_BFC
    {
        private static PCM1_Setup instance;
        public static PCM1_Setup Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PCM1_Setup();
                }
                return instance;
            }
        }
        private PCM1_Setup()
        {
        }
     
        ...
    }
