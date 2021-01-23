    public bool IsCertificateValid(string regNo, string redirectTo)
    {
        redirectTo = null;
        try
        {
            var _dbRegn = _db.StudentRegistrations
                        .Where(r => r.RegistrationNumber == regNo)
                        .FirstOrDefault();
            if (_dbRegn != null)
            {
                var _isCertificateIssued = _dbRegn.IsCertificateIssued.Value;
                if (_isCertificateIssued)
                {
                  // unimportant code...
                }
                else
                {
                     redirectTo = "CertificateNotApproved";
                }
            }
            else
            {
                 redirectTo = "CertificateDontExist";
            }
        }
        catch (Exception ex)
        {
            redirectTo  = "CertificateDontExist";
        }
        return !string.IsNullOrEmpty(redirectTo);
    }
