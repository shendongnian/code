       //System.ServiceModel.Channels.Binding binding;
        System.ServiceModel.Channels.IBindingRuntimePreferences binding;
        if(bindingObject == "basic")
           binding = new System.ServiceModel.BasicHttpBinding();}
        else
           binding = new System.ServiceModel.WSHttpBinding();
