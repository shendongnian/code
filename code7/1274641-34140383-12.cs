    public class UpdateManifestsTask : Task
    {
        public ITaskItem ClientManifest { get; set; }
        public ITaskItem ServerManifest { get; set; }
        public ITaskItem Version { get; set; }
    
        public override bool Execute()
        {
            var newVersion = string.Format("name=\"SoftBrands.FourthShift.FSCulture\" version=\"{0}\"", this.Version.ItemSpec);
            var clientFile = File.ReadAllText(this.ClientManifest.ItemSpec);
            clientFile = Regex.Replace(clientFile, "name=\"SoftBrands.FourthShift.FSCulture\" version=\"\\d*\\.\\d*\\.\\d*\\.\\d*\"", newVersion);
            File.WriteAllText(this.ClientManifest.ItemSpec, clientFile);
            var serverFile = File.ReadAllText(this.ClientManifest.ItemSpec);
            serverFile = Regex.Replace(clientFile, "name=\"SoftBrands.FourthShift.FSCulture\" version=\"\\d*\\.\\d*\\.\\d*\\.\\d*\"", newVersion);
            File.WriteAllText(this.ServerManifest.ItemSpec, serverFile);
    
            return true;
        }
    }
