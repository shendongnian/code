        // retrieve ingredient quantity by equipement
        using (Model.CapacityGrid oModel = new Model.CapacityGrid(Configuration.RemoteDatabase))
       {  // <-- **add these**
            oQuantity = oModel.SelectByFormula(strFormulaName, iVersionId);
         
        // code to throw the exception
        var o = (oQuantity[0].EquipmentSection.TypeId);
       } // <-- **add these**
