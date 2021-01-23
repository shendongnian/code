    private void button3_Click(object sender, EventArgs e)
        {
            String choice;
            switch (comboBox1.SelectedIndex)
            {
                case 0: //player
                    choice = "Player";
                    break;
                case 1://weight
                    choice = "Weight";
                    break;
                case 2://catapult
                    choice = "CatapultHead";
                    break;
                case 3://ropething
                    choice = "RopeEndingSmall";
                    break;
                case 4://ropethingbig
                    choice = "RopeReleaseSmall";
                    break;
                case 5://turncross
                    choice = "TurnCrossSmall";
                    break;
                default:
                    choice = "Blah";
                    break;
            }
            Random rand = new Random();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathtree);
            //XmlReader xmlReader = XmlReader.Create(pathtree);
            XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            List<double> z = new List<double>();
            ////MyObjectBuilder_Sector/SectorObjects/MyObjectBuilder_EntityBase[@xsi:type = 'MyObjectBuilder_CubeGrid']/CubeBlocks/MyObjectBuilder_CubeBlock[@xsi:type = 'MyObjectBuilder_CubeBlock']/SubtypeName
            //xmlReader.
            while (true)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0: //player
                        x.Add( Convert.ToDouble(xmlDoc.SelectSingleNode("//MyObjectBuilder_Sector/SectorObjects/MyObjectBuilder_EntityBase[@xsi:type = 'MyObjectBuilder_Character']/PositionAndOrientation/Position", nsmanager).Attributes["x"].Value) );
                        y.Add( Convert.ToDouble(xmlDoc.SelectSingleNode("//MyObjectBuilder_Sector/SectorObjects/MyObjectBuilder_EntityBase[@xsi:type = 'MyObjectBuilder_Character']/PositionAndOrientation/Position", nsmanager).Attributes["y"].Value) );
                        z.Add( Convert.ToDouble(xmlDoc.SelectSingleNode("//MyObjectBuilder_Sector/SectorObjects/MyObjectBuilder_EntityBase[@xsi:type = 'MyObjectBuilder_Character']/PositionAndOrientation/Position", nsmanager).Attributes["z"].Value) );
                        break;
                    case 1:
                        XmlNodeList nodeCollection = xmlDoc.SelectNodes("//MyObjectBuilder_Sector/SectorObjects/MyObjectBuilder_EntityBase[@xsi:type = 'MyObjectBuilder_CubeGrid']",nsmanager);
                        if (nodeCollection != null) { 
                        textBox2.Text += nodeCollection.Count;
                        }
                        for (int j = 0; j < nodeCollection.Count; j++)
                        {
                            ///////
                            if (nodeCollection[j].SelectSingleNode("//CubeBlocks/MyObjectBuilder_CubeBlock[@xsi:type = 'MyObjectBuilder_CubeBlock']/SubtypeName",nsmanager).InnerText.Equals("Weight"))
                            {
                                var position = nodeCollection[j].SelectSingleNode("//PositionAndOrientation/Position");
                                x.Add(Convert.ToDouble(position.Attributes["x"].Value));
                                y.Add(Convert.ToDouble(position.Attributes["y"].Value));
                                z.Add(Convert.ToDouble(position.Attributes["z"].Value));
                            }
                        }
                        //xmlReader.ReadToFollowing()
                        //xmlDoc.SelectNodes()
                        //x.add(from type in xmlDoc.SelectSingleNode("//MyObjectBuilder_Sector/SectorObjects/MyObjectBuilder_EntityBase[@xsi:type = 'MyObjectBuilder_Character']/PositionAndOrientation/Position", nsmanager));
                        //Select x.value('Description[1]','varchar(max)') as 'description' FROM xmlDoc.SelectNodes('//IncomeItem[TypeId=29]') i(x)
                        break;
                        
                    case 2://catapult
                        break;
                    case 3://ropething
                        break;
                    case 4://ropethingbig
                        break;
                    case 5://turncross
                        break;
                    default:
                        break;
                }
                break;
                /*
                x.Add( Convert.ToDouble(xmlDoc.SelectSingleNode("//MyObjectBuilder_Sector/SectorObjects/MyObjectBuilder_EntityBase[@xsi:type = 'MyObjectBuilder_Character']/PositionAndOrientation/Position", nsmanager).Attributes["x"].Value) );
                y.Add( Convert.ToDouble(xmlDoc.SelectSingleNode("//MyObjectBuilder_Sector/SectorObjects/MyObjectBuilder_EntityBase[@xsi:type = 'MyObjectBuilder_Character']/PositionAndOrientation/Position", nsmanager).Attributes["y"].Value) );
                z.Add( Convert.ToDouble(xmlDoc.SelectSingleNode("//MyObjectBuilder_Sector/SectorObjects/MyObjectBuilder_EntityBase[@xsi:type = 'MyObjectBuilder_Character']/PositionAndOrientation/Position", nsmanager).Attributes["z"].Value) );
                */
            }
            for (int i = 0; i < (x.Count); i++)
            {
                createTree(x[i], y[i], z[i]);
                textBox2.Text += "\r\nCREATED A TREE\r\n";
            }
        }
