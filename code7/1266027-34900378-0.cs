namespace GetIISWebsites
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CustomAction1(Session xiSession)
        {
            System.Diagnostics.Debugger.Launch();
            Microsoft.Deployment.WindowsInstaller.View lView = xiSession.Database.OpenView("DELETE FROM ComboBox WHERE ComboBox.Property='xxxxxxxx'");
            lView.Execute();
            lView = xiSession.Database.OpenView("SELECT * FROM ComboBox");
            lView.Execute();
            List<string> instances = RetrieveIISWebsites();
            int Counter = 0;
            int Index = 0;
            bool flag = false;
            try
            {
                foreach (string str in instances)
                {
                    Record lRecord = xiSession.Database.CreateRecord(4);
                    lRecord.SetString(1, "xxxxxxxx");
                    lRecord.SetInteger(2, Index);
                    lRecord.SetString(3, str);
                    lRecord.SetString(4, str);
                    lView.Modify(ViewModifyMode.InsertTemporary, lRecord);
                    Counter = Index;
                    ++Index;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                xiSession.Log("Exception Details: " + ex.Message);
            }
            lView.Close();
            xiSession.Log("Closing view");
            lView.Close();
            return ActionResult.Success;
        }
        private static List<string> RetrieveIISWebsites()
        {
            List<string> result = new List<string>();
            var websites = GetSites();
            foreach (Site site in websites)
            {
                result.Add(site.Name);
            }
           
            return result;
        }
        private static SiteCollection GetSites()
        {
            var iisManager = new ServerManager();
            SiteCollection sites = iisManager.Sites;
            return sites;
        }
    }
}
