    public class ObjectFactory : MonoBehaviour()
    {
       public GameObject prefab;  // Set this through the editor.
    
       public void GenerateObject()
       {
          // This will create a copy of the "prefab" object and its Start method will get called:
          Instantiate(prefab);
       }
    }
