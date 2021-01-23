    [TypeConverterAttribute(typeof(TreeNodeConverter)), Serializable,
    DefaultProperty("Text"),    
    SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly")]
    public class TreeNode : MarshalByRefObject, ICloneable, ISerializable {
        object userData;
        protected virtual void Serialize(SerializationInfo si, StreamingContext context) {
            // SNIP storage of irrelevant fields.
            if (userData != null && userData.GetType().IsSerializable) {
                si.AddValue("UserData", userData, userData.GetType());
            }
        }
        public object Tag {
            get {
                return userData;
            }
            set {
                userData = value;
            }
        }
     }
