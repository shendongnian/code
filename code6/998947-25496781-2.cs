    public class Phantom
        {
            private PhantomJSDriver _driver;
            //Move this field to base class if you need to start site before each test
            //e.g. you can move setup and teardown to base class, it's all up to you
            public DevServer WebDevServer { get; private set; }
    
            [SetUp]
            public void WhenOpeningANewWebPage()
            {
                WebDevServer = new DevServer();
                WebDevServer.Start();
    
                _driver = new PhantomJSDriver();
                _driver.Navigate().GoToUrl(@"localhost");
            }
    
            [Test]
            public void ThenICanFindAClass()
            {
                Assert.NotNull(_driver.FindElement(By.ClassName("featured")));
            }
    
            [TearDown]
            public void Finally()
            {
                _driver.Quit();
                WebDevServer.Stop();
            }
    
        }
    
    
        public class DevServer
        {
            private Server _webServer;
    
    		public DirectoryInfo SourcePath { get; set; }
    
    		public string VirtualPath { get; set; }
    
    		public int Port { get; set; }
    
            public DevServer()
    		{
                //Port
    			Port = Settings.WebDevPort;
    			//Path to your site folde
                SourcePath = Settings.WebDevSourcePath;
    			//Virt path can be ~
                VirtualPath = Settings.WebDevVirtualPath;
    		}
    
    		public void Start()
    		{
    			Stop();
    
    			try
    			{
    				_webServer = new Server(Port, VirtualPath, SourcePath.FullName);
    				_webServer.Start();
    			}
    			catch (Exception e)
    			{
    				Trace.TraceError("Process cannot be started." + Environment.NewLine + e);
    				throw;
    			}
    		}
    
    		public void Stop()
    		{
    			if (_webServer != null)
    			{
    				_webServer.Stop();
    				_webServer = null;
    			}
    		}
        }
