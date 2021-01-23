    protected override Object GetMachineDesign(SubSystem model, Design context)
    {
        return new MyMachine
        {
            SecondarySysName = model.SecondarySysName,
            SysSerial = model.SysSerial,
            PrimarySysName = model.PrimarySysName
            PrimaryAssemblyLocation = context.Location;
        };
    }
