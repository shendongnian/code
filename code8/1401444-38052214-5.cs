    internal class JctRestartViaSmsAttemptTestRunner : ITestRunner<JctRestartViaSmsAttempt>
    {
        private readonly IMayWantMonitoring _queues;
        private readonly IAppSettings _appSettings;
    
        public JctRestartViaSmsAttemptTestRunner(IMayWantMonitoring queues, IAppSettings appSettings)
        {
            _queues = queues;
            _appSettings = appSettings;
        }
    
        public JctTest Execute(JctRestartViaSmsAttempt jctMessageType)
        {
            // after five minutes, publish an event to check if the JCT logged in
            var jctLoggedInTimeOut = TimeSpan.FromMinutes(double.Parse(_appSettings["JctLogInTimeOut"]));
            var message = new JctRestartViaSmsValidate(jctMessageType.Imei);
    
            Thread.Wait(jctLoggedInTimeOut.Milliseconds);
    
            _queues.Publish(message);
    
            // reset test values
            return new JctTest("6", jctMessageType.Imei, null, null, null);
        }
    }
