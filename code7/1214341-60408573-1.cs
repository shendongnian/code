    public class ExampleWriter : MonoBehaviour
    {
        // Here you drag in the ScriptableObject instance via the Inspector in Unity
        [SerializeField] private ExampleScriptableObject example;
        public void StoreData(string someString, int someInt, Vector3 someVector, List<byte[]> someDatas)
        {
            example.someStringValue = someString;
            example.someCustomData = new CustomDataClass
                                     {
                                         example = someInt;
                                         custom = someVector;
                                         data = new Dictionary<int, byte[]>();
                                     };
            for(var i = 0; i < someDatas.Count; i++)
            {
                example.someCustomData.data.Add(i, someDatas[i]);
            }
        }
    }
    
