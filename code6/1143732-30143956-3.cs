    var ins1 = new Instruction { Op = OpCodes.Add, Operand = (short)5 };
    var ins2 = new Instruction { Op = OpCodes.Sub, Operand = 5.0 };
    byte[] bytes;
    using (var ms = new MemoryStream())
    {
        var bf = new BinaryFormatter();
        bf.Serialize(ms, ins1);
        bf.Serialize(ms, ins2);
        bytes = ms.ToArray();
    }
    Instruction ins3, ins4;
    using (var ms = new MemoryStream(bytes))
    {
        var bf = new BinaryFormatter();
        ins3 = (Instruction)bf.Deserialize(ms);
        ins4 = (Instruction)bf.Deserialize(ms);
    }
