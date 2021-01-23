        log4net.Config.XmlConfigurator.Configure();
        
        try
        {
            new Thread((p) => StartModbusSerialRtuSlave()).Start();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        //Start your form the right way!
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
