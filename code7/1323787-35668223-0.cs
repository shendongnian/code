    public class ExampleClass : MonoBehaviour
    {
        void Example()
        {
            if (Application.isEditor)
            {
                print("We are running this from inside of the editor!");
            }
        }
    }
