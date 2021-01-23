        private async void CheckForUpdate()
        {
            try
            {
                using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/dartvalince/DiscerningEye"))
                {
                    updateManager = mgr;
                    var release = await mgr.UpdateApp();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message + Environment.NewLine;
                if (ex.InnerException != null)
                    message += ex.InnerException.Message;
                MessageBox.Show(message);
            }
        }
