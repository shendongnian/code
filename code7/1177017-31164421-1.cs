    public static XmlNodeList GetDetailPageSectionBySa(string sa, string statementXml)
    {
        XmlDocument document = new XmlDocument();
        document.LoadXml(statementXml);
        string requestSa = sa.PadLeft(9, '0');
        string xpath = String.Format("//Para[IRBILGP_SA_SAA_ID_PRINT.SERVICE.ACCOUNT.STATMENT='{0}S{1}']/..", requestSa.Substring(0, 4), requestSa.Substring(4));
        return document.SelectNodes(xpath);
        if(!SaExistInBill(requestSa, statementXml)) return null;
        var node = GetDetailPageSectionByBillPrisminfoIndex(sa, statementXml);
        if (node != null) return node;
        return null;
    }
