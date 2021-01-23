    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace BrowserExample
    {
        public class ExtendedBrowser : WebBrowser
        {
    
            protected sealed class WebBrowserControlSite : WebBrowser.WebBrowserSite, IServiceProvider
            {
                DownloadManagerImplementation manager;
    
                public WebBrowserControlSite(WebBrowser host)
                    : base(host)
                {
                    manager = new DownloadManagerImplementation();
                   
                }
    
                public int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
                {
                    Guid SID_SDownloadManager = new Guid("988934A4-064B-11D3-BB80-00104B35E7F9");
                    Guid IID_IDownloadManager = new Guid("988934A4-064B-11D3-BB80-00104B35E7F9");
    
                    if ((guidService == IID_IDownloadManager && riid == IID_IDownloadManager))
                    {
                        ppvObject = Marshal.GetComInterfaceForObject(manager, typeof(IDownloadManager));
                        return 0; //S_OK
                    }
                    ppvObject = IntPtr.Zero;
                    return unchecked((int)0x80004002); //NON_INTERFACE (use the default, please)
                }
            }
    
    
            protected override WebBrowserSiteBase CreateWebBrowserSiteBase()
            {
                return new WebBrowserControlSite(this);
            }
    
    
        }
    }
