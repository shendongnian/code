    void Main()
    {
    	
    	var os = Tshort.Convesionfailed.ToStringOct().Dump();         //000120
    	BasedEnumConverter<Tshort>.ParseEnumFromOct(os).Dump();       //Conversionfailed
    	
    	var stsbbin = Tsbyte.BAD.ToStringBin().Dump();				  //10000000
    	BasedEnumConverter<Tsbyte>.ParseEnumFromBin(stsbbin).Dump();  //BAD
    	
    	var sinthex = Tint.OK.ToStringHex().Dump();					  //00000080
    	BasedEnumConverter<Tint>.ParseEnumFromHex(sinthex).Dump();    //OK
    	
    }
    
    enum Tenum : byte { A = 0, B = 1, OK = 128, BAD = 255, Convesionfailed = 80 }
    enum Tbyte : byte { A = 0, B = 1, OK = 128, BAD = 255, Convesionfailed = 80 }
    enum Tsbyte : sbyte { A = 0, B = 1, OK = 127, OK2 = 126, BAD = -128, BAD2 = -127, Convesionfailed = 80 }
    enum Tshort : short { A = 0, B = 1, OK = 128, BAD = 255, Convesionfailed = 80 }
    enum Tushort : ushort { A = 0, B = 1, OK = 128, BAD = 255, Convesionfailed = 80 }
    enum Tint : int { A = 0, B = 1, OK = 128, BAD = 255, Convesionfailed = 80 }
    enum Tuint: uint { A = 0, B = 1, OK = 128, BAD = 255, Convesionfailed = 80 }
    enum Tlong : long { A = 0, B = 1, OK = 128, BAD = 255, Convesionfailed = 80 }
    enum Tulong : ulong { A = 0, B = 1, OK = 128, BAD = 255, Convesionfailed = 80, Min = ulong.MinValue, Max = ulong.MaxValue}
