    //This will also work as we still have MonoBehaviour in a root of our inheritance
    public class TestScript : BaseTest
    {
    }
    //This will not be assignable from Inspector
    public abstract class BaseTest : MonoBehaviour
    {
    }
