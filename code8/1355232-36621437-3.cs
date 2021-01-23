    public ET_ITAM_RequestDetails GetAssociateFreewareRequestDetails()
    {
        ET_ITAM_RequestDetails objET_ITAM_RequestDetails = new ET_ITAM_RequestDetails();
        SqlDataReader rdr = null;
        connect.Open();
        SqlCommand cmd = new SqlCommand("ET_ITAM_GetAssociateFreewareRequestDetails", connect);
        cmd.CommandType = CommandType.StoredProcedure;
    
        while (rdr.Read())
        {
            objET_ITAM_RequestDetails.AssociateID = (string)rdr[0];
            objET_ITAM_RequestDetails.AssetID = (string)rdr[1];
            objET_ITAM_RequestDetails.ETRequestID = (int)rdr[2];
            objET_ITAM_RequestDetails.FreewareName = (string)rdr[3];
            objET_ITAM_RequestDetails.InstallationCommand = (string)rdr[4];
            objET_ITAM_RequestDetails.InstallationArguments = (string)rdr[5];
            objET_ITAM_RequestDetails.VerificationType = (bool)rdr[6];
            objET_ITAM_RequestDetails.VerificationPath = (string)rdr[7];
        }
    
        return objET_ITAM_RequestDetails;
    }
