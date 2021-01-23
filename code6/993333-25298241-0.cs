        log4net.Config.XmlConfigurator.Configure();
        Form1 form = new Form1();
        form.Show();
        try
        {
            new Thread((p) => StartModbusSerialRtuSlave()).Start();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
