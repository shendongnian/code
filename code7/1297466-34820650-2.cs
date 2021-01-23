    //crowd.cs
    public class Crowd : MonoBehaviour
    {
        public enum crowdOptions {None, TeamA, TeamB};
        public static crowdOptions CrowdOptions;
    }
    public class Winning : MonoBehaviour
    {
        void Start()
        {
            if(CrowdOptions == crowdOptions.None)
            {
                //do something
            }
         }
    }
   
