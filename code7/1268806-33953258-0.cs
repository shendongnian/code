            XmlReader xmlFile;
            xmlFile = XmlReader.Create("XMLPATH should be here", new   XmlReaderSettings());
            
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);
            int row_count = ds.Tables[0].Rows.Count;
            int coloumn_count = ds.Tables[0].Columns.Count;
            string[,] data = new string[row_count,coloumn_count ];
           
            for (int i = 0; i < row_count; i++)
            {
                data[i, 0] = ds.Tables[0].Rows[i][0].ToString();
                data[i, 1] = ds.Tables[0].Rows[i][1].ToString();
                data[i, 2] = ds.Tables[0].Rows[i][2].ToString();
                data[i, 3] = ds.Tables[0].Rows[i][3].ToString();
                data[i, 4] = ds.Tables[0].Rows[i][4].ToString();
                data[i, 5] = ds.Tables[0].Rows[i][5].ToString();
                data[i, 6] = ds.Tables[0].Rows[i][6].ToString();
                data[i, 7] = ds.Tables[0].Rows[i][7].ToString();
                data[i, 8] = ds.Tables[0].Rows[i][8].ToString();
                data[i, 9] = ds.Tables[0].Rows[i][9].ToString();
            }
