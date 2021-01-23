    public class PropertyContainingClass
    {
        public int MyProperty
        {
            get
            {
                if(isRunningLocal)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }
        private bool isRunningLocal{ get; set; }
        public PropertyContainingClass()
        {
            this.isRunningLocal = //code to determine whether running local
        }
    }
