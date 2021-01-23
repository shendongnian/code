    //Type
    var t = Client.GetType();
    //Properties "Changes the name property of Client"
    PropertyInfo Client_Name = t.GetProperty("Name");
    Client_Name.SetValue(Client, "NEW NAME");
    
    //Registers "Gets an array from the Client"
    FieldInfo Registers = t.GetField("Registers");
    Array arr = (Array)Registers.GetValue(Client);
    Label_Register1.Text = String.Format("0x{0:x4}", arr.GetValue(246));
    Label_Register2.Text = String.Format("0x{0:x4}", arr.GetValue(247));
    //Mothods "Executes a method with parameters {_portClient to , 1 }"
    MethodInfo method = t.GetMethod("Execute");
    method.Invoke(Client, new object[] { _portClient, Convert.ToByte(1), Convert.ToByte(4), 247, 2, 1 });
