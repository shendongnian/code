    public enum MachineType
    {
        Native = 0, I386 = 0x014c, Itanium = 0x0200, x64 = 0x8664
    }
    public static MachineType GetMachineType(string fileName)
    {
        // dos header is 64 bytes
        // PE header address is 4 bytes
        const int PE_PTR_OFFSET = 60;
        const int MACHINE_OFFSET = 4;
        byte[] data = new byte[4096];
        using (Stream stm = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            stm.Read(data, 0, 4096);
        }
        int PE_HDR_ADDR = BitConverter.ToInt32(data, PE_PTR_OFFSET);
        int machineUint = BitConverter.ToUInt16(data, PE_HDR_ADDR + MACHINE_OFFSET);
        return (MachineType)machineUint;
    }
