    // retrieve ingredient quantity by equipement
    using (Model.CapacityGrid oModel = new Model.CapacityGrid(Configuration.RemoteDatabase))
    {
        oQuantity = oModel.SelectByFormula(strFormulaName, iVersionId);
        
        // Lazy-load occurs here, so it needs to have access to the
        // context, hence why it is in the using statement.
        var o = (oQuantity.First().EquipmentSection.TypeId);
    }
