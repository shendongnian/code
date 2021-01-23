    // Build xml file path (target)
    string targetFile = "";
    targetFile = Path.Combine(this.txtTargetPath.Text, _servicedDataSet.DataSetName + ".xml");
    // To import the xml file in Excel two files are being generated: xml and xsd. 
    // When mapping the xml file to excel the columns and tables with null values goes missing.
    // Mapping the xsd file solves the problem. Therefore, we are generating two separate xml and xsd files.
    // xsd for the structure and xml for the data.
    if (chkSchema.Checked == true)
    {
        // Build xsd file path (xsdtarget)
        string xsdtargetFile = "";
        xsdtargetFile = Path.Combine(this.txtTargetPath.Text, _servicedDataSet.DataSetName + ".xsd");
        // Publish the dataset as XML
        _servicedDataSet.WriteXml(targetFile, XmlWriteMode.IgnoreSchema);
        // Creating the xsd file from the dataset.
        string schema = _servicedDataSet.GetXmlSchema();
        // Encoding utf-16 is not compatible with Excel. Changing utf-16 to utf-8 sorts the problem
        string result = schema.Replace("utf-16", "utf-8");
        System.IO.File.WriteAllText(xsdtargetFile, result);
    }
