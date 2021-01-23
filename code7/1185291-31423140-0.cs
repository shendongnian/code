    private static string previouStatusMessage;
    private static object lockObject = new object();
    static void model_ModelBuildStatusUpdate(StaadModel sender, ModelBuildStatusUpdateEventArgs e)
        {
            lock (lockObject)
            {
                if (string.IsNullOrEmpty(previouStatusMessage) || !previouStatusMessage.Equals(e.StatusMessage))
                {
                    Console.WriteLine(e.StatusMessage);
                    previouStatusMessage = e.StatusMessage;
                }
            }
            Console.Write("\r{0:0.00%}", e.ElementsProcessed / (double)e.TotalElementsToProcess);
        }
