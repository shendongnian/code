    if (otype == EA.ObjectType.otDiagram)
            {
                EA.Diagram diag = Repository.GetDiagramByID(ID);
                foreach (EA.DiagramObject dobj in diag.DiagramObjects)
                {
                    EA.Element el = Repository.GetElementByID(dobj.ElementID);
                    foreach (EA.Connector con in el.Connectors)
                    {
                        if (con.Type == "Sequence")
                        {
                               MessageBox.Show(con.Name);
                        }
                    }
                }
            }
