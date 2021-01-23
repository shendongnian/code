       protected override void OnStart(string[] args)
        {
                 _LogHelper.Init();
                 _LogHelper.AddFileLogging...
                 _LogHelper.AddSMTPLogging...
                 _Logger.DebugFormat("Start....
                 _Timer = new Timer(AppConfig.Interval);
                 _Timer.AutoReset =   true;
                 _Timer.Elapsed += new ElapsedEventHandler(this._Timer_Tick);
                 _Timer.Start();
        }
       private void _Timer_Tick(object sender, ElapsedEventArgs e)
        {
           _Timer.Stop();
           try
           {
              using (MailingService _MailingServices = new MailingService(1000000))
              {
                 _MailingServices.ProcessMailingPLinQ(); //Parallel
                 //_MailingServices.ProcessMailingParallel(); //PLINQ
              }
           }
           catch (Exception _Exception)
           {
              _Logger.ErrorFormat("Exception: {0}", _Exception.GetExceptionAll());
           }
           finally
           {
              _Timer.Start();
           }
        }
        
    
    Services.cs
    
          public void ProcessMailingPLinQ()
          {
             Entities.Configuration.AutoDetectChangesEnabled = false;
             Entities.Configuration.ProxyCreationEnabled = false;
             MandrillApi _MandrillApi = new MandrillApi(AppConfig.MailAPIKey);
             try
             {
                _Logger.Debug("Start ProcessMailing()");
                GetvMailingListaReadyToSend(5000)
                              .AsParallel()
                              .Select(M => ProcessMail(M)).ToArray();
                //Query paginated
             }
             catch (Exception _Exception)
             {
                _Logger.ErrorFormat(....);
             }
             _Logger.Debug("End ProcessMailing()");
          }
    
          public void ProcessMailingParallel()
          {
             Entities.Configuration.AutoDetectChangesEnabled = false;
             Entities.Configuration.ProxyCreationEnabled = false;
             MandrillApi _MandrillApi = new MandrillApi(AppConfig.MailAPIKey);
             try
             {
                _Logger.Debug("Start ProcessMailing()");
                Parallel.ForEach(GetvMailingListaReadyToSend(5000).AsParallel(),
                   new ParallelOptions { MaxDegreeOfParallelism = 100 },
                   _MailingLista => ProcessMail(_MailingLista));
                //Query paginated
             }
             catch (Exception _Exception)
             {
                _Logger.ErrorFormat(....);
             }
             _Logger.Debug("End ProcessMailing()");
          }
    
    public EmailResult ProcessMail(vMailingListaReadyToSend vMailingLista)
    {
       EmailResult _EmailResult = null;
       try
       {
          //Create 
          EmailMessage _EmailMessage = new EmailMessage()
          {
             .....
          };
    
          //Sending
          _EmailResult = _MandrillApi.SendMessage(_EmailMessage).FirstOrDefault();
    
          //Update
          using (MailingEntities _MailingEntitiesUpdate = new MailingEntities())
          {
             _MailingEntitiesUpdate.SPUpdateMailingLista(Id, DateTime.Now, false);
          }
       }
       catch (Exception _Exception)
       {
          _Logger.ErrorFormat(...);
       }
       return _EmailResult;
    }
    
    
    EntityFramework.cs
    IEnumerable<vMailingListaReadyToSend> GetvMailingListaReadyToSend(int vItems)
    {
             return Entities.vMailingListaReadyToSend.AsNoTracking().Take(vItems);
    }
