    public class Instruction
    {
        public OpCode Op { get; set; }
        public string OpString
        {
            get
            {
                return Op.Name;
            }
            set
            {
                Op = (OpCode)typeof(OpCodes).GetField(value, BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase).GetValue(null);
            }
        }
        public object Operand { get; set; }
    }
