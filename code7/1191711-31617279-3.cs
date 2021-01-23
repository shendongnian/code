    if (meterReadEndXMLNodes.Count > 0 && meterReadEndXMLNodes[0].HasChildNodes)
    {   // This is to fill up the meter read end date and meter read end usage as an attribute of the "sadetails" node in the newer XML.
        DateTime latestDateTime = new DateTime();
        string latestUsage = "";
        foreach (var node in meterReadStartXMLNodes)
        {
            DateTime tempDateTime = DateTime.Parse(String.Format("{0} 01 {1}", meterReadStartXMLNodes[0].SelectSingleNode("IRBILGU_US_USG_END_DT_MM.USAGE").InnerText,
                                                                            meterReadStartXMLNodes[0].SelectSingleNode("IRBILGU_US_USG_END_DT_DD.USAGE").InnerText));
            if (tempDateTime > latestDateTime)
            {
                // Any time you've determined you have an newer date, we capture the usage for that date
                latestDateTime = tempDateTime;
                latestUsage = meterReadStartXMLNodes[0].SelectSingleNode("IRBILGU_US_KWH_MTR_READ.USAGE").InnerText;
            }
        }
        saBillDetail.UsageMeterReadEndDate = latestDateTime.ToString("MMM yy");
        saBillDetail.UsageMeterReadEndUsage = latestUsage;
    }
