    if (data.StartsWith("Coloumns"))
        data = data.Substring(index + 1, data.Length - (index + 1));
    data = data.Trim(); 
    string[] values = data.Split(',');
    // Add the index on the column on which data is stored in csv
    List<int> csvIndex = new List<int>();
    for (int i = 0; i < values.Length; i++)
    {
        values[i] = values[i].Trim();
        if (values[i] != "Status")
            csvIndex.Add(csvHeaders.IndexOf(values[i]));                        
    }
    rfidindex = (csvHeaders.IndexOf("RFID") == -1) ? csvHeaders.IndexOf("rfid") : csvHeaders.IndexOf("RFID");
    //Image myImage = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("search.png"));
     //ImageConverter imageConverter = new ImageConverter();
    Image img = AssetGatherMobileQuickTraQ.Properties.Resources.search;
        //Properties.Resources.my_image;
    string csvdata = strRdr.ReadToEnd();
    csvdata = csvdata.Replace('\r', ' ');
    string[] tagDets = csvdata.Split(new char[] { '\n' });
    csvItems = new Hashtable();
    DataTable dataTable1 = (DataTable)scnDataGrd.DataSource;
    for (int i = 0; i < tagDets.Length; i++)
    {
        string[] individTagDet = tagDets[i].Split(new char[] { ',' });
        if (individTagDet.Length <= 1)
            break;
        csvItems.Add(individTagDet[rfidindex].Replace("\"", string.Empty).Trim(), individTagDet);                                                                       
        DataRow row = dataTable1.NewRow();
        row.BeginEdit();
        //System.Drawing.Image imgTest = System.Drawing.Image. FromFile("C:\\Test.jpg");
        //System.Drawing.Image img = System.Drawing.Image.ReferenceEquals
        //dataTable1.Columns
        Bitmap image1 = new System.Drawing.Bitmap(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\search.png");
        //scnDataGrd.Dara
        row[0] = image1;
        //DataGrid
        for (int j = 0; j < 3; j++)
        {
            row[j+1] = individTagDet[csvIndex[j]].Replace("\"",string.Empty).Trim();                            
        }
        //scnDataGrd.TableStyles
        csvRfidList.Add(individTagDet[rfidindex].Replace("\"", string.Empty).Trim());
        missingTagList.Add(individTagDet[rfidindex].Replace("\"", string.Empty).Trim());
        
        row.EndEdit();
        dataTable1.Rows.Add(row);
        DataColumn cCurrent = new DataColumn("Current", typeof(bool));
        dataTable1.Rows.Add(cCurrent);
        scnDataGrd.DataSource = dataTable1;
    }
