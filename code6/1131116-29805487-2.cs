    public static XmlDocument ConfigurXMLReport(string path, Dictionary<string, string> Columns)
        {
            XmlDocument objXmlDocument = new XmlDocument();
            objXmlDocument.Load(path);
            XmlNamespaceManager mgr = new XmlNamespaceManager(objXmlDocument.NameTable);
            string uri = "http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition";
            mgr.AddNamespace("df", uri);
            //locate and create nodes for cloning and modification
            XmlNode tablixCols = objXmlDocument.SelectSingleNode("/df:Report/df:Body/df:ReportItems/df:Tablix/df:TablixBody/df:TablixColumns", mgr);
            XmlNode dataField = objXmlDocument.SelectSingleNode("/df:Report/df:DataSets/df:DataSet/df:Fields/df:Field", mgr);
            XmlNode tablixMember = objXmlDocument.SelectSingleNode("/df:Report/df:Body/df:ReportItems/df:Tablix/df:TablixColumnHierarchy/df:TablixMembers/df:TablixMember", mgr);
            XmlNode rowHeaders = objXmlDocument.SelectSingleNode("/df:Report/df:Body/df:ReportItems/df:Tablix/df:TablixBody/df:TablixRows/df:TablixRow", mgr);
            XmlNode rowValues = rowHeaders.NextSibling.SelectSingleNode("./df:TablixCells", mgr);
            rowHeaders = rowHeaders.SelectSingleNode("./df:TablixCells", mgr);
            XmlNode sampleCol = tablixCols.SelectSingleNode("./df:TablixColumn", mgr);
            XmlNode sampleHeader = rowHeaders.SelectSingleNode("./df:TablixCell", mgr);
            XmlNode sampleValue = rowValues.SelectSingleNode("./df:TablixCell", mgr);
            //Iterate through the column definitions and add nodes to the xml to support the columns
            foreach (KeyValuePair<string,string> column in Columns)
            {
                //clone the sample nodes into new nodes
                XmlNode newDataField = dataField.CloneNode(true);
                newDataField.SelectSingleNode("./df:DataField", mgr).InnerText = column.Key;
                newDataField.Attributes["Name"].Value = column.Key;
                dataField.ParentNode.AppendChild(newDataField);
                XmlNode newCol = sampleCol.CloneNode(true);
                XmlNode newHeader = sampleHeader.CloneNode(true);
                XmlNode newValue = sampleValue.CloneNode(true);
                //update the new nodes with the column data
                newHeader.SelectSingleNode("./df:CellContents/df:Textbox", mgr).Attributes["Name"].Value = "Header" + column.Key;
                newValue.SelectSingleNode("./df:CellContents/df:Textbox", mgr).Attributes["Name"].Value = "Value" + column.Key;
                //because I use friendly column names - modify the report output to use the friendly name as the display value
                newHeader.SelectSingleNode("./df:CellContents/df:Textbox/df:Paragraphs/df:Paragraph/df:TextRuns/df:TextRun/df:Value", mgr).InnerText = column.Value;
                newValue.SelectSingleNode("./df:CellContents/df:Textbox/df:Paragraphs/df:Paragraph/df:TextRuns/df:TextRun/df:Value", mgr).InnerText = string.Format("=Fields!{0}.Value", column.Key);
                //add the new nodes to the document
                tablixCols.AppendChild(newCol);
                rowHeaders.AppendChild(newHeader);
                rowValues.AppendChild(newValue);
                tablixMember.ParentNode.AppendChild(tablixMember.CloneNode(true));
            }
            //remove the nodes used for cloning
            objXmlDocument.SelectSingleNode("/df:Report/df:DataSets/df:DataSet/df:Fields", mgr).RemoveChild(dataField);
            objXmlDocument.SelectSingleNode("/df:Report/df:Body/df:ReportItems/df:Tablix/df:TablixColumnHierarchy/df:TablixMembers", mgr).RemoveChild(tablixMember);
            tablixCols.RemoveChild(sampleCol);
            rowHeaders.RemoveChild(sampleHeader);
            rowValues.RemoveChild(sampleValue);
            //return the completed report definition
            return objXmlDocument;
        }
