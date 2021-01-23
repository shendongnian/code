    [Serializable]
    public class MyClass
    {
        public int MySerializedProperty { get; set; }
        [NonSerialized]
        public string MyNonSerializedProperty { get; set; }
    }
