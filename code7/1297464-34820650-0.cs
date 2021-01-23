    public class Crowd : MonoBehaviour
    {
        public enum crowdOptions {None, TeamA, TeamB};
        public crowdOptions crowdOpts;
    }
    public class Winning : MonoBehaviour
    {
        Crowd myCrowd = new Crowd();
        if(myCrowd.crowdOpts == crowdOptions.None)
        {
            //do something
        }
    }
