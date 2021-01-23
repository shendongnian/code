    public class UpdateManifestsTask : Task
    {
        public ITaskItem ClientManiftest { get; set; }
        public ITaskItem ServerManiftest { get; set; }
        public ITaskItem Version { get; set; }
    
        public override bool Execute()
        {
            var newVersion = string.Format("name=\"SoftBrands.FourthShift.FSCulture\" version=\"{0}\"", this.Version.ItemSpec);
            var clientFile = File.ReadAllText(this.ClientManiftest.ItemSpec);
            clientFile = Regex.Replace(clientFile, "name=\"SoftBrands.FourthShift.FSCulture\" version=\"\\d*\\.\\d*\\.\\d*\\.\\d*\"", newVersion);
            File.WriteAllText(this.ClientManiftest.ItemSpec, clientFile);
            var serverFile = File.ReadAllText(this.ClientManiftest.ItemSpec);
            serverFile = Regex.Replace(clientFile, "name=\"SoftBrands.FourthShift.FSCulture\" version=\"\\d*\\.\\d*\\.\\d*\\.\\d*\"", newVersion);
            File.WriteAllText(this.ServerManiftest.ItemSpec, serverFile);
    
            return true;
        }
    }
