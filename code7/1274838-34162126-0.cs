        public async Task StartAzureRunbook()
        {
            string tenant = "you.onmicrosoft.com";
            string clientId = "appclientId";
            string appKey = "appkey";
            string aadInstance = "https://login.microsoftonline.com/{0}/";
            string authority = string.Format(CultureInfo.InvariantCulture, aadInstance, tenant);
            authContext = new AuthenticationContext(authority);
            clientCredential = new ClientCredential(clientId, appKey);
            if (clientCredential != null)
            {
                AuthenticationResult result = null;
                int retryCount = 0;
                bool retry = false;
                do
                {
                    retry = false;
                    try
                    {
                        result = await authContext.AcquireTokenAsync("https://management.core.windows.net/", clientCredential);
                    }
                    catch (AdalException ex)
                    {
                        if (ex.ErrorCode == "temporarily_unavailable")
                        {
                            retry = true;
                            retryCount++;
                            Thread.Sleep(3000);
                        }
                        Console.WriteLine(
                            String.Format("An error occurred while acquiring a token\nTime: {0}\nError: {1}\nRetry: {2}\n",
                            DateTime.Now.ToString(),
                            ex.ToString(),
                            retry.ToString()));
                    }
                } while ((retry == true) && (retryCount < 3));
                if (result != null)
                {
                    try
                    {
                        var subscriptionId = "azure subscription Id";
                        string base64cer = "****long string here****"; //taken from http://stackoverflow.com/questions/24999518/azure-api-the-server-failed-to-authenticate-the-request
                        var cert = new X509Certificate2(Convert.FromBase64String(base64cer));
                        var client = new Microsoft.Azure.Management.Automation.AutomationManagementClient(new CertificateCloudCredentials(subscriptionId, cert));
                        var ct = new CancellationToken();
                        var content = await client.Runbooks.ListByNameAsync("MyAutomationAccountName", "MyRunbookName", ct);
                        var firstOrDefault = content?.Runbooks.FirstOrDefault();
                        if (firstOrDefault != null)
                        {
                            var operation = client.Runbooks.Start("MyAutomationAccountName", new RunbookStartParameters(firstOrDefault.Id));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }
