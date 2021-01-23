    public void OnCheckFillBPMN()
    {
        Color fillColor = Color.FromArgb(1, 255, 0, 0);
        CollapsedSubProcessFill(this.Application.ActiveWindow.Selection.PrimaryItem, fillColor);
    }
    
    private void CollapsedSubProcessFill(Visio.Shape vShpIn, Color fillColor)
    {
        if (vShpIn != null && vShpIn.Master != null && vShpIn.Master.NameU.StartsWith("Collapsed Sub-Process"))
        {
            //The sub-shape that provides the fill colour in 
            //the 'Collapsed Sub-Process' master is the first index
            //after the group shape. 
            //If you want to use a different method to locate the 
            //correct sub-shape then do that here.
            var targetSubShpId = vShpIn.ID + 1;
            var targetShp = TryGetShapeInCollection(vShpIn.Shapes, targetSubShpId);
            if (targetShp != null)
            {
                var targetCell = targetShp.get_CellsSRC(
                    (short)Visio.VisSectionIndices.visSectionObject,
                    (short)Visio.VisRowIndices.visRowFill,
                    (short)Visio.VisCellIndices.visFillForegnd);
                targetCell.FormulaU = "RGB(" + fillColor.R
                                        + ',' + fillColor.G
                                        + ',' + fillColor.B + ')';
            }
        }
    }
    
    
    private Visio.Shape TryGetShapeInCollection(Visio.Shapes vShps, int shpId)
    {
        try
        {
            if (vShps != null)
            {
               var targetShp = vShps.ItemFromID[shpId];
               return targetShp; 
            }  
        }
        catch (System.Runtime.InteropServices.COMException ex)
        {
            if (ex.ErrorCode == -2032465756) //Invalid sheet identifier
            {
                return null;
            }
        }
        return null;
    }
