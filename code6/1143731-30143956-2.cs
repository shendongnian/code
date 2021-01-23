    [Serializable]
    public class Instruction : ISerializable 
    {
        public OpCode Op { get; set; }
        public object Operand { get; set; }
        public Instruction()
        {
        }
        public Instruction(SerializationInfo info, StreamingContext context)
        {
            Op = (OpCode)typeof(OpCodes).GetField(info.GetString("Op"), BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase).GetValue(null);
            Operand = info.GetValue("Operand", typeof(object));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Op", Op.Name);
            info.AddValue("Operand", Operand);
        }
    }
