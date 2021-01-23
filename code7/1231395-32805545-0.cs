    private bool IsTrial()
        {
            var li = CurrentApp.LicenseInformation;
            if (li.IsActive)
            {
                return li.IsTrial;
            }
            else
            {
                return true;
            }
        }
