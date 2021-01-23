    [Serializable]
    public class ChildClass : ParentClass, ISerializable
    {
        public int m_child = 73;
        public ChildClass()
        { }
        public ChildClass(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Debug.WriteLine("Loading child");
            m_child = (int)info.GetValue("m_child", typeof(int));
        }
        public new void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Debug.WriteLine("Saving child");
            info.AddValue("m_child", m_child, typeof(int));
            base.GetObjectData(info, context);
        }
    }
