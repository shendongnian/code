    public static WebServiceHost InitializeAndStartWebServiceHost(int port, string endPointName, object serviceModel, Type implementedContractType) {
            var baseAddress = new Uri($"http://0.0.0.0:{port}/{endPointName}");
            WebServiceHost host;
            try {
                host = new WebServiceHost(serviceModel, baseAddress);
            } catch (Exception exception) {
                Debug.Print("Error when creating WebServiceHost, message: " + exception.Message);
                return null;
            }
            // ReSharper disable once UseObjectOrCollectionInitializer
            var binding = new WebHttpBinding();
            binding.UseDefaultWebProxy = false;
            binding.BypassProxyOnLocal = true;
            //By default, TransferMode is Buffered which causes C# wcf client to be slow as hell (>500ms for requests which give >2kB responses).
            //I am not exactly sure why this helps, but it helps!
            binding.TransferMode = TransferMode.Streamed;
            host.AddServiceEndpoint(implementedContractType, binding, "");
            var behavior = new WebHttpBehavior();
            behavior.HelpEnabled = false;
            behavior.DefaultBodyStyle = WebMessageBodyStyle.Bare;
            // We will use json format for all our messages.
            behavior.DefaultOutgoingRequestFormat = WebMessageFormat.Json;
            behavior.DefaultOutgoingResponseFormat = WebMessageFormat.Json;
            behavior.AutomaticFormatSelectionEnabled = false;
            behavior.FaultExceptionEnabled = true;
            host.Description.Endpoints[0].Behaviors.Add(behavior);
            try {
                host.Open();
            } catch (AddressAccessDeniedException) {
                Console.WriteLine(@"Application must run with administrator rights.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return host;
        }
