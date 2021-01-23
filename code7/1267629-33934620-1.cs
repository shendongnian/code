    public class LicenseWatchingServiceUICreator : ILicenseWatchingServiceUIHost
        {
    
            public void Execute(List<LicenseInfoContainerExpiring> elcs, List<LicenseInfoContainerUntrusted> ulcs)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => 
                {
                    LicenseWatchingServiceUserInterface LWSUI = new LicenseWatchingServiceUserInterface(elcs, ulcs); 
                }));
            }
    
        }
