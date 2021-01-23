                        XmlReader inner = xr.ReadSubtree();
                        while (inner.Read())
                        {
                            if (xr.NodeType == XmlNodeType.Text)
                            {
                                 //Do stuff
                            }
                        }
