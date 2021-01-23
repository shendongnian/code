    using (SportsTimerEntities ctx = new SportsTimerEntities(
     @"metadata=res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl;
      provider=System.Data.SqlClient;
      provider connection string=""Data Source=(LocalDB)\\v11.0;
      AttachDbFilename=C:\\Work\\SportsTimer\\Events\\559eae6a-9974-4463-8546-00824b4aad23.mdf;
      Integrated Security=True;
      Pooling=false;
      MultipleActiveResultSets=True;
      Connect Timeout=30;
      Application Name=EntityFramework"""))
    {
       dbDevices = ctx.Devices.ToList();
    }
