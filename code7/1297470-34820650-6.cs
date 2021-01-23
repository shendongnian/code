    public class Crowd : MonoBehaviour
    {
        public enum crowdOptions {None, TeamA, TeamB};
        public static crowdOptions CrowdOptions;
    }
    public class Winning : MonoBehaviour
    {
        void Start()
        {
            if(CrowdOptions == Crowd.crowdOptions.None)
            {
                //do something
            }
         }
    }
   
