    Public dynamic GetBinding(string bindingObject)
     {
        if (bindingObject == "basic")
        {
            binding = new System.ServiceModel.BasicHttpBinding();
        }
        else
        {
            binding = new System.ServiceModel.WSHttpBinding();
        }
       return binding;
      }
