    string string1 = "Modbus";
    string string2 = "Client";
    string string3 = "RTU";
    var modbusClientType = Type.GetType("DataExchange.Modbus." + string1 + string2 + ",DataExchange.Modbus");
    var modbusRtuType = Type.GetType("DataExchange.Modbus." + string1 + string3 + ",DataExchange.Modbus");
    var modbusRtuInstance = Activator.CreateInstance(modbusRtuType);
    var Client = Activator.CreateInstance(modbusClientType, modbusRtuInstance);
