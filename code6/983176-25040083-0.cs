            GridView gv1 = new GridView();
            XDocument rndfile = XDocument.Load(@"C:\Users\...\rndfile.xml");
            var rootele = rndfile.Descendants("ADRESSE").First().Elements();
            int counter = 0;
            //Create empty Listview depending on Sub-entrys of ADRESSE
            foreach (XElement xele in rootele)
            {
                GridViewColumn gvc = new GridViewColumn();
                gvc.DisplayMemberBinding = new Binding("Feld"+counter);//gets a Binding name Feld# for each child
                gvc.Header = xele.Name.LocalName; //Name my Columns after the <tags> of the childs
                gv1.Columns.Add(gvc);  //add the current Column to my Gridview
                counter++;
            } //Listview created
            //Fill my list for every single Parent-element in my XML file
                foreach (XElement xe in rndfile.Descendants("ADRESSE"))
                {
                     lv1.Items.Add(new
                        {
                            Feld0 = xe.Element("NAME1").Value,
                            Feld1 = xe.Element("NAME2").Value,
                            Feld2 = xe.Element("STRASSE1").Value,
                            Feld3 = xe.Element("STRASSE2").Value,
                            Feld4 = xe.Element("LAND").Value,
                            Feld5 = xe.Element("PLZ").Value,
                            Feld6 = xe.Element("ORT").Value
                        });
                    
                }//List filled 
