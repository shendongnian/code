    public bool FeatureIsInstalled(string name)
    {
        bool result = false;
        using (Pipeline pipeline = runspace.CreatePipeline(
            string.Format("Get-WindowsFeature '{0}'", name)))
        {
            Collection<PSObject> output = pipeline.Invoke();
            if (output.Count > 0)
            {
                dynamic o1 = output[0];
                result = (bool)o1.Installed;
            }
        }
        return result;
    }
