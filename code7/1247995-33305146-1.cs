    internal class PrimaryAssemblyMachineBuilder : MachineBuilderBase
    {
        protected abstract IMachine GetMachineDesign(TModel mode, TContext context)
        {
            // Do some de-serialisation.
            return new PrimaryAssemblyMachine(primarySysName, 
                                                sysSerial, 
                                                secondarySysName, 
                                                primaryAssemblyLocation);
        }
    }
