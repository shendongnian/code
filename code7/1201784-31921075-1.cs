    // Gateway participant that impersonates a phone user
    // _gatewayEndpoint = _helper.CreateApplicationEndpoint(
    // "GatewayParticipant" /*endpointFriendlyName*/);
    public ApplicationEndpoint CreateApplicationEndpoint(string contactFriendlyName)
        {
            string prompt = string.Empty;
            if (string.IsNullOrEmpty(contactFriendlyName))
            {
                contactFriendlyName = "Default Contact";
            }
            Console.WriteLine();
            Console.WriteLine("Creating Application Endpoint {0}...", contactFriendlyName);
            Console.WriteLine();
            // If application settings are provided via the app.config file, then use them
            // Else prompt user for details
            if (!ReadApplicationContactConfiguration())
            {
                // Prompt user for server FQDN. If server FQDN was entered before, then let the user use the saved value.
                if (string.IsNullOrEmpty(_serverFqdn))
                {
                    prompt = "Please enter the FQDN of the Microsoft Lync Server for this topology => ";
                    _serverFqdn = PromptUser(prompt, null);
                }
                if (string.IsNullOrEmpty(_applicationHostFQDN))
                {
                    prompt = "Please enter the FQDN of the Machine that the application service is configured to => ";
                    _applicationHostFQDN = PromptUser(prompt, null);
                }
                if (0 >= _applicationPort)
                {
                    // Prompt user for contact port
                    prompt = "Please enter the port that the application service is configured to => ";
                    _applicationPort = int.Parse(PromptUser(prompt, null), CultureInfo.InvariantCulture);
                }
                if (string.IsNullOrEmpty(_applicationGruu))
                {
                    // Prompt user for Contact GRUU
                    prompt = "Please enter the GRUU assigned to the application service => ";
                    _applicationGruu = PromptUser(prompt, null);
                }
                if (string.IsNullOrEmpty(_applicationContactURI))
                {
                    // Prompt user for contact URI
                    prompt = "Please enter the Contact URI in the User@Host format => ";
                    _applicationContactURI = PromptUser(prompt, null);
                    if (!_applicationContactURI.Trim().StartsWith(_sipPrefix, StringComparison.OrdinalIgnoreCase))
                    {
                        _applicationContactURI = _sipPrefix + _applicationContactURI.Trim();
                    }
                }
                if (string.IsNullOrEmpty(_certificateFriendlyName))
                {
                    // Prompt user for contact URI
                    prompt = "Please enter the friendly name of the certificate to be used => ";
                    _certificateFriendlyName = PromptUser(prompt, null);
                }
            }
            // Reuse platform instance so that all endpoints share the same platform.
            if (_serverCollabPlatform == null)
            {
                CreateAndStartServerPlatform();
            }
            // Initalize and register the endpoint.
            // NOTE: the _applicationContactURI should always be of the form "sip:user@host"
            ApplicationEndpointSettings appEndpointSettings = new ApplicationEndpointSettings(_applicationContactURI, _serverFqdn, 5061);
            _applicationEndpoint = new ApplicationEndpoint(_serverCollabPlatform, appEndpointSettings);
            _endpointInitCompletedEvent.Reset();
            Console.WriteLine("Establishing the endpoint...");
            _applicationEndpoint.BeginEstablish(EndEndpointEstablish, _applicationEndpoint);
            // Sync; wait for the registration to complete.
            _endpointInitCompletedEvent.WaitOne();
            Console.WriteLine("Application Endpoint established...");
            return _applicationEndpoint;
        }
