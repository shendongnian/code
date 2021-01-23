    [DataContract(Name = "Entity", Namespace = "myContract.com/dto")]
    public abstract class Entity
    {
        [DataMember(Name = "__type", Order = 0)]
        public string EntityTypeName
        {
            get
            {
                var typeName = GetType().Name;
                if (Attribute.IsDefined(GetType(), typeof(DataContractAttribute)))
                {
                    var attribute = GetType().GetCustomAttributes(typeof(DataContractAttribute), true).FirstOrDefault() as DataContractAttribute;
                    if (attribute != null) typeName = typeName + ":" + attribute.Namespace;
                }
                return typeName;
            }
        }
    }
