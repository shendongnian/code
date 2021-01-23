    public class Animal<T> : MonoBehaviour where T : MonoBehaviour
    {       
    }
    public class Quadruped<T> : Animal<T> where T : MonoBehaviour
    {
    }
    public class Dog : Quadruped<Dog>
    {
    }
