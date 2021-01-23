    public class MyInstallationService : CodeFirstInstallationService
    {
        public override void InstallData(string defaultUserEmail,
            string defaultUserPassword, bool installSampleData = true)
        {
            // Let the base class do it´s install logic
            base.InstallData(defaultUserEmail, defaultUserPassword, installSampleData);
            // Do my own logic
            // Install flux capacitor etc
        }
    }
