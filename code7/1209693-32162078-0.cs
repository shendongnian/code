    if(File.Exists("TimeLog.xml"))
        {
            XmlReader r = XmlReader.Create("TimeLog.xml");
            r.MoveToContent();
      //Here check whether there exist a root element and then also check itsname.
      //If this doesn't work out then put the r.Name=="TimeLog" inside While loop and then see.
           
        if (reader.IsStartElement() && r.Name == "TimeLog")
            {
                while (r.Read())
                {
                    if (r.NodeType == XmlNodeType.Element)
                    {
                        r.ReadToDescendant("EntryName");
                        String name = r.ReadInnerXml();
                        r.ReadToFollowing("StartDateTime");
                        String start = r.ReadInnerXml();
                        r.ReadToFollowing("EndDateTime");
                        String end = r.ReadInnerXml();
                        r.ReadToFollowing("Duration");
                        String dur = r.ReadInnerXml();
                        entries.Add(new Entry(name, start, end, dur));
                    }//End of inner If
                }//End of While
            }//End of Outer second IF
            else
            {
                MessageBox.Show("This is not a TimeLog XML file", "This is not a TimeLog XML file", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }//End of Else
            r.Close();
