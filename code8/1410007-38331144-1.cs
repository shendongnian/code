    string filePath = Properties.Resources.ResourceManager.GetString("FilePath");
                string fileName = Properties.Resources.ResourceManager.GetString("FileName");
                string fileLocation = filePath + fileName;
        string connstr = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + fileLocation + ";" + "Extended Properties=" + "\"" + "Excel 12.0 Xml;IMEX=1;HDR=NO;" + "\"";
                        OleDbConnection conn = new OleDbConnection(connstr);
        foreach (var i in sheets)
                    {
                if (ExcelUtil.isEmptySheet2(result,conn) == true)
                        {
        
                            //set button false
                            i.btnFood = false;
                        }
                        else
                        {
                            i.btnFood = true;
                        }
                    }
