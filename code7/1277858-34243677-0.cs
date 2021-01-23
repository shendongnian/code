    namespace Assets.Code.Scripts
    {
        public class TimeManager
        {
            public static int gametime 
            { 
               get { return (int)Time.timeSinceLevelLoad / 5;  }
            }
        }
    }
