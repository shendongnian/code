    class ILReader {
        readonly byte[] msil;
        int ptr;
        public ILReader(byte[] msil) {
            this.msil = msil;
        }
        public OpCode OpCode { get; private set; }
        public int MetadataToken { get; private set; }
        public object Operand { get; private set; }
        public bool Read(MethodInfo methodInfo) {
            if(ptr < msil.Length) {
                OpCode = ReadOpCode();
                Operand = ReadOperand(OpCode, methodInfo);
                return true;
            }
            return false;
        }
        OpCode ReadOpCode() {
            byte instruction = ReadByte();
            if(instruction != 254)
                return singleByteOpCode[instruction];
            else
                return doubleByteOpCode[ReadByte()];
        }
        object ReadOperand(OpCode code, MethodInfo methodInfo) {
            MetadataToken = 0;
            switch(code.OperandType) {
                case OperandType.InlineMethod:
                    MetadataToken = ReadInt();
                    System.Type[] methodArgs = null;
                    if(methodInfo.GetType() != typeof(ConstructorInfo))
                        methodArgs = methodInfo.GetGenericArguments();
                    System.Type[] typeArgs = null;
                    if(methodInfo.DeclaringType != null)
                        typeArgs = methodInfo.DeclaringType.GetGenericArguments();
                    return methodInfo.Module.ResolveMember(MetadataToken, typeArgs, methodArgs);
            }
            return null;
        }
        byte ReadByte() {
            return msil[ptr++];
        }
        int ReadInt() {
            byte b1 = ReadByte();
            byte b2 = ReadByte();
            byte b3 = ReadByte();
            byte b4 = ReadByte();
            return (int)b1 | (((int)b2) << 8) | (((int)b3) << 16) | (((int)b4) << 24);
        }
        #region static
        static ILReader() {
                CreateOpCodes();
            }
        static OpCode[] singleByteOpCode;
        static OpCode[] doubleByteOpCode;
        static void CreateOpCodes() {
            singleByteOpCode = new OpCode[225];
            doubleByteOpCode = new OpCode[31];
    
            FieldInfo[] fields = GetOpCodeFields();
    
            for(int i = 0; i < fields.Length; i++) {
                OpCode code = (OpCode)fields[i].GetValue(null);
                if(code.OpCodeType == OpCodeType.Nternal)
                    continue;
    
                if(code.Size == 1)
                    singleByteOpCode[code.Value] = code;
                else
                    doubleByteOpCode[code.Value & 0xff] = code;
            }
        }
        static FieldInfo[] GetOpCodeFields() {
            return typeof(OpCodes).GetFields(BindingFlags.Public | BindingFlags.Static);
        }
        #endregion static
    }
