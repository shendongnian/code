    try {
    
     var resourceContext = ResourceContext.GetForCurrentView();
     resourceContext.QualifierValues.MapChanged += QualifierValuesMapChanged;
    }
    catch(Exception ex){ 
    ex.Handled = true;
    Debug.Write(ex.Message);
    }
