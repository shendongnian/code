                     while (pointReader.Read())
                      {
                        if (pointReader.NodeType == XmlNodeType.Element || pointReader.NodeType== XmlNodeType.Text)
                         {
                          if (pointReader.Name == "azsa:x")
                           {
                              point[0] = pointReader.ReadElementContentAsDouble();
                           }
                          else if (pointReader.Name == "")
                           {
                              point[1] = Double.Parse(pointReader.Value);
                           }
                         else if (pointReader.Name == "azsa:z")
                           {
                         point[2] = pointReader.ReadElementContentAsDouble();
                           }
                        }
                     }
