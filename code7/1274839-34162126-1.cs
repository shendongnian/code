        public async Task StartAzureRunbook()
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
