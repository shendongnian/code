CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
//reset connection
DBController.LogonEx(DBAlias, "", DBUsername, DBPassword);
//Create the QE (query engine) propertybag with the provider details and logon property bag
CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag QE_Details = new CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag();
ConnectionInfo ci = DBController.GetConnectionInfos(null)[0];
//copy from existing attributes except for server name
for (int idx = 0; idx < ci.Attributes.PropertyIDs.Count; idx++)
{
    switch (ci.Attributes.PropertyIDs[idx])
    {
        case "QE_ServerDescription":
            QE_Details.Add(ci.Attributes.PropertyIDs[idx], DBAlias);
            break;
        case "QE_LogonProperties":
            //this is itself a property bag
            CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag logonDetails = new CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag();
            PropertyBag OLDLogon = (PropertyBag)ci.Attributes[ci.Attributes.PropertyIDs[idx]];
            for (int idx2 = 0; idx2 < OLDLogon.PropertyIDs.Count; idx2++)
            {
                switch (OLDLogon.PropertyIDs[idx2])
                {
                    case "Server":
                    case "Data Source":
                        logonDetails.Add(OLDLogon.PropertyIDs[idx2], DBAlias);
                        break;
                    default:
                        logonDetails.Add(OLDLogon.PropertyIDs[idx2], OLDLogon[OLDLogon.PropertyIDs[idx2]]);
                        break;
                }
            }
            QE_Details.Add(ci.Attributes.PropertyIDs[idx], logonDetails);
            break;
        default:
            QE_Details.Add(ci.Attributes.PropertyIDs[idx], ci.Attributes[ci.Attributes.PropertyIDs[idx]]);
            break;
    }
}
//now replace all existing connections with new one
CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo newConnInfo = new CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo();
newConnInfo.Attributes = QE_Details;
newConnInfo.Kind = CrystalDecisions.ReportAppServer.DataDefModel.CrConnectionInfoKindEnum.crConnectionInfoKindCRQE;
newConnInfo.UserName = DBUsername;
newConnInfo.Password = DBPassword;
foreach (CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo oldConnInfo in DBController.GetConnectionInfos(null))
{
    DBController.ReplaceConnection(oldConnInfo, newConnInfo.Clone(true), null, CrystalDecisions.ReportAppServer.DataDefModel.CrDBOptionsEnum.crDBOptionDoNotVerifyDB);
}
