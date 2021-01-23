    class FirefoxDriverEx : FirefoxDriver {
        private static DesiredCapabilities Capabilities() {
            var capa = DesiredCapabilities.Firefox();
            capa.SetCapability(CapabilityType.UnexpectedAlertBehavior, "accept");
            return capa;
        }
        public FirefoxDriverEx()
            : base(Capabilities()) { }
        protected override Response Execute(string driverCommandToExecute, Dictionary<string, object> parameters) {
            try{
                return base.Execute(driverCommandToExecute, parameters);
            } catch (UnhandledAlertException) {
                return base.Execute(driverCommandToExecute, parameters);
            }
        }
    }
    
