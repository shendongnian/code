    public virtual void Emit(OpCode opcode, MethodInfo meth)
    {
        //...
        if (opcode.Equals(OpCodes.Call) || opcode.Equals(OpCodes.Callvirt) || opcode.Equals(OpCodes.Newobj))
        {
            EmitCall(opcode, meth, null);
        }
        else
        {
            // ...
        }
    }
