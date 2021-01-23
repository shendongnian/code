        /// <summary>
        /// Returns the https certificate used for a given local IIS website.
        /// </summary>
        /// <param name="sWebsite">Website url, e.g., "https://myserver.company.com"</param>
        /// <returns>certificate, null if not found</returns>
        private X509Certificate2 FindIisHttpsCert(string sWebsite)
        {
          Uri uriWebsite = new Uri(sWebsite);
          using (ServerManager sm = new ServerManager())
          {
            string sBindingPort = string.Format(":{0}:", uriWebsite.Port);
            Binding bdBestMatch = null;
            foreach (Site s in sm.Sites)
            {
              foreach (Binding bd in s.Bindings)
              {
                if (bd.BindingInformation.IndexOf(sBindingPort) >= 0)
                {
                  string sBindingHostInfo = bd.BindingInformation.Substring(bd.BindingInformation.LastIndexOf(':') + 1);
                  if (uriWebsite.Host.IndexOf(sBindingHostInfo, StringComparison.InvariantCultureIgnoreCase) == 0)
                  {
                    if ((bd.Protocol == "https") && ((bdBestMatch == null) || (bdBestMatch.BindingInformation.Length < bd.BindingInformation.Length)))
                      bdBestMatch = bd;
                  }
                }
              }
            }
            if (bdBestMatch != null)
            {
              StringBuilder sbThumbPrint = new StringBuilder();
              for (int i = 0; i < bdBestMatch.CertificateHash.Length; i++)
                sbThumbPrint.AppendFormat("{0:X2}", bdBestMatch.CertificateHash[i]);
              X509Store store = new X509Store(bdBestMatch.CertificateStoreName, StoreLocation.LocalMachine);
              store.Open(OpenFlags.ReadOnly);
              X509Certificate2Collection coll = store.Certificates.Find(X509FindType.FindByThumbprint, sbThumbPrint.ToString(), true);
              if (coll.Count > 0)
                return coll[0];
            }
          }
          return null; // if no matching site was found
        }
