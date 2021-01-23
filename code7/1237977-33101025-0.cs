      short iRow = (short)Visio.VisRowIndices.visRowFirst;
                while (shape.get_CellsSRCExists((short)Visio.VisSectionIndices.visSectionProp, iRow, (short)Visio.VisCellIndices.visCustPropsValue, (short)Visio.VisExistsFlags.visExistsAnywhere) != 0)
                {
                    Visio.Cell c = shape.get_CellsSRC((short)Visio.VisSectionIndices.visSectionProp, iRow, (short)Visio.VisCellIndices.visCustPropsValue);
                             switch (c.Name)
                            {
                                case "Prop.BpmnTriggerOrResult":
                                    shape.Cells[c.Name].FormulaU = "\"" + "Message" + "\"";
                                    break;
    
                            }
    }
                      
