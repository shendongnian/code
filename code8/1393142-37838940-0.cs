    [MulticastAttributeUsage(PersistMetaData = true)]
    public class TlvContractAttribute : TypeLevelAspect
    {
        public override void CompileTimeInitialize(Type target, AspectInfo aspectInfo)
        {
            Dictionary<int, PropertyInfo> indexes = new Dictionary<int, PropertyInfo>();
            foreach (PropertyInfo propertyInfo in target.GetProperties())
            {
                TlvMemberAttribute memberAttr =
                    propertyInfo.GetCustomAttributes()
                        .Where(x => x is TlvMemberAttribute)
                        .Cast<TlvMemberAttribute>()
                        .SingleOrDefault();
                if (memberAttr == null)
                {
                    Message.Write(MessageLocation.Of(propertyInfo), SeverityType.Error, "USR001",
                        "Property {0} should be marked by TlvMemberAttribute.", propertyInfo);
                    continue;
                }
                if (indexes.ContainsKey(memberAttr.Index))
                {
                    Message.Write(MessageLocation.Of(propertyInfo), SeverityType.Error, "USR002",
                        "Property {0} marked by TlvMemberAttribute uses Index {1}, which is already used by property {2}.",
                        propertyInfo, memberAttr.Index, indexes[memberAttr.Index]);
                    continue;
                }
                indexes[memberAttr.Index] = propertyInfo;
            }
        }
    }
