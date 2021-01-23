    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices.ComTypes;
    using System.Windows.Forms;
    
    namespace BrowserExample
    {
        [System.Runtime.InteropServices.ComVisible(true)]
        [System.Runtime.InteropServices.Guid("bdb9c34c-d0ca-448e-b497-8de62e709744")]
        public class DownloadManagerImplementation : IDownloadManager
        {
    
            /// <summary>
            /// Return S_OK (0) so that IE will stop to download the file itself. 
            /// Else the default download user interface is used.
            /// </summary>
            public int Download(IMoniker pmk, IBindCtx pbc, uint dwBindVerb, int grfBINDF,
               IntPtr pBindInfo, string pszHeaders, string pszRedir, uint uiCP)
            {
                // Get the display name of the pointer to an IMoniker interface that specifies
                // the object to be downloaded.
                string name = string.Empty;
                pmk.GetDisplayName(pbc, null, out name);
    
                if (!string.IsNullOrEmpty(name))
                {
                    Uri url = null;
                    bool result = Uri.TryCreate(name, UriKind.Absolute, out url);
    
                    if (result)
                    {
                        //Implement your custom download manager here
                        //Example:
                        //WebDownloadForm manager = new WebDownloadForm();
                        //manager.FileToDownload = url.AbsoluteUri;
                        //manager.Show();
                        MessageBox.Show("Download URL is: " + url);
                        return 0; //Return S_OK
                    }
                }
                return 1; //unspecified error occured.
            }
    
        }
