    public class MyObjectSerializer : CodeDomSerializer
    {
        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            return new CodeVariableReferenceExpression((value as MyReferencableObject).FullName);
        }
    }`
