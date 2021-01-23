    internal static DataTable ReadGpxFile(string gpxfile)
        {
            AFolderFiles.AFolderFilesPermission.AddFolderSecurity(gpxfile);
            DataTable table = new DataTable("gpxfile");
            table.Columns.Add("ident", typeof(string));
            table.Columns.Add("lat", typeof(string));
            table.Columns.Add("long", typeof(string));
            table.Columns.Add("time", typeof(string));
            XmlDocument gpxDoc = new XmlDocument();
            gpxDoc.Load(gpxfile);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(gpxDoc.NameTable);
            nsmgr.AddNamespace("x", "http://www.topografix.com/GPX/1/1");
            XmlNodeList nl = gpxDoc.SelectNodes("//x:trkpt", nsmgr);
            foreach (XmlElement xelement in nl)
            {
                DataRow dataRow = table.NewRow();
                dataRow[0] = string.IsNullOrEmpty(xelement.GetAttribute("ident")) == true ? "GPXFILE" : xelement.GetAttribute("ident");
                dataRow[1] = xelement.GetAttribute("lat");
                dataRow[2] = xelement.GetAttribute("lon");
                dataRow[3] = xelement.GetAttribute("time");
                table.Rows.Add(dataRow);
            }
            return table;
        }
 
