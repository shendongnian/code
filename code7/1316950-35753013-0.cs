    public abstract class ScreenController : MonoBehaviour
    {
    }
    
    public class SpecificScreenController : ScreenController
    {
        private static SpecificScreenController _instance;
        public static SpecificScreenController Instance{ get{... return _instance;} 
    }
