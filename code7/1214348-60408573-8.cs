    public class ExmpleConsumer : MonoBehaviour
    {
        // Here you drag in the same ScriptableObject instance via the Inspector in Unity
        [SerializeField] private ExampleScriptableObject example;
        public void ExampleLog()
        {
            Debug.Log($"string: {example.someString}", this);
            Debug.Log($"int: {example.someCustomData.example}", this);
            Debug.Log($"vector: {example.someCustomData.custom}", this);
            Debug.Log($"data: There are {example.someCustomData.data.Count} entries in data.", this);
        }
    }
