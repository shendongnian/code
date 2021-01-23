    // This is the first namespace with all classes set to internal.
    namespace ControlClient
    {
        internal class ClientStarter
        {
            internal IArcManagerConsole mngrConsole;
            internal ClientStarter() { }
            internal IManagerConsole GetSrvcManagerConsole(/*. all the parameters . */)
            {
                ConsoleBuildDirector cnslBldDirector = new ConsoleBuildDirector();
                IConsoleBuilder fedBuilder = new Federated_ConsoleBuilder();
                cnslBldDirector.DirectBuildingConsole(fedBuilder);
          
                mngrConsole = fedBuilder.GetSrvcManagerConsole();
                return mngrConsole;
            }
        }
    }
