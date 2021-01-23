        public override bool CheckLicense(string domain, FeatureEnum feature, ObjectActionEnum action)
        {
            if (domain != null)
                domain = LicenseKeyInfoProvider.ParseDomainName(domain);
            int siteId = LicenseHelper.GetSiteIDbyDomain(domain);
            var licenseKey = LicenseKeyInfoProvider.GetLicenseKeyInfo(domain, FeatureEnum.Unknown);
            if (siteId > 0 && licenseKey != null)
            {
                // TODO: query external service with licenseKey.Domain for a valid license for this module
                return true;
            }
            return false;
        }
