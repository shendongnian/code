     Opc.Da.Server server = null;
    
    static void readplc()
            {
                    Opc.URL url = new Opc.URL("opcda://localhost/RSLinx OPC Server");
                Opc.Da.Server server = null;
                OpcCom.Factory fact = new OpcCom.Factory();
                **this.server = new Opc.Da.Server(fact, null);**
        ....
        }
