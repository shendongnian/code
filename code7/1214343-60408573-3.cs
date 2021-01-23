    using UnityEngine;
    
    // fileName is the default name when creating a new Instance
    // menuName is where to find it in the context menu of Create
    [CreateAssetMenu(fileName = "Data", menuName = "Examples/ExamoleScriptableObject")]
    public class ExampleScriptableObject : ScriptableObject
    {
        public string someStringValue = "";
        public CustomDataClass someCustomData = null;
    
        // Could also implement some methods to set/read data,
        // do stuff with the data like parsing between types, fileIO etc
        // Especially ScriptableObjects also implement OnEnable and Awake
        // so you could still fill them with permanent data via FileIO at the beginning of your app and store the data via FileIO in OnDestroy !!
    }
    // If you want the data to be stored permanently in the editor
    // and e.g. set it via the Inspector
    // your types need to be Serializable!
    //
    // I intentionally used a non-serializable class here to show that also 
    // non Serializable types can be passed between scenes 
    public class CustomDataClass
    {
        public int example;
        public Vector3 custom;
        public Dictionary<int, byte[]> data;
    }
