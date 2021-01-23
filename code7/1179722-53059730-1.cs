    public class IntegrationProcessor
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private static volatile bool _workerIsRunning;
        private int _updateInterval;
        private ProjectIntegrationService _projectIntegrationService;
        public IntegrationProcessor(int updateInterval, ProjectIntegrationService projectIntegrationService, Timer timer)
        {
            _updateInterval = updateInterval;
            _projectIntegrationService = projectIntegrationService;
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = _updateInterval;
            //Don't wait for first elapsed time - Should not be used when running as a service due to that Starting will hang up until the queue is empty
            if (Environment.UserInteractive)
            {
                OnTimedEvent(null, null);
            }
            _workerIsRunning = false;
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                if (_workerIsRunning == false)
                {
                    _workerIsRunning = true;
                    ProjectInformationToGet infoToGet = null;
                    _logger.Info($"Started looking for information to get");
                    //Run until queue is empty
                    while ((infoToGet = _projectIntegrationService.GetInformationToGet()) != null)
                    {
                        //Set debugger on logger below to control how many cycles the service should run while debugging.
                        var watch = System.Diagnostics.Stopwatch.StartNew();
                        _logger.Info($"Started Stopwatch");
                        _logger.Info($"Found new information, updating values");
                        _projectIntegrationService.AddOrUpdateNewInformation(infoToGet);
                        _logger.Info($"Completed updating values");
                        watch.Stop();
                        _logger.Info($"Stopwatch stopped. Elapsed seconds: {watch.ElapsedMilliseconds / 1000}. " +
                                     $"Name queue items: {infoToGet.NameQueueItems.Count} " +
                                     $"Case queue items: {infoToGet.CaseQueueItems.Count} " +
                                     $"Fee calculation queue items: {infoToGet.FeeCalculationQueueItems.Count} " +
                                     $"Updated foreign keys: {infoToGet.ShouldUpdateKeys}");
                    }
                    _logger.Info($"Nothing more to get from integration service right now");
                    _workerIsRunning = false;
                }
                else
                {
                    _logger.Info($"Worker is already running! Will check back again after {_updateInterval / 1000} seconds");
                }
            }
            catch (DbEntityValidationException exception)
            {
                var newException = new FormattedDbEntityValidationException(exception);
                HandelException(newException);
                throw newException;
            }
            catch (Exception exception)
            {
                HandelException(exception);
                //If an exception occurs when running as a service, the service will restart and run again
                if (Environment.UserInteractive)
                {
                    throw;
                }
            }
        }
        private void HandelException(Exception exception)
        {
            _logger.Fatal(exception);
            _workerIsRunning = false;
        }
    }
