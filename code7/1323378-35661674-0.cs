    foreach(dynamic inst in instances)
    {
         Type type = inst.GetType();
         Type interfaceType = type.GetInterfaces().Single(t => t == generic);
         interfaceType.GetMethod("Handle").Invoke(inst, new object[] { m });
    }
