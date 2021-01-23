    using System.Collections.Generic;
    public List<Dictionary<String, String>> getProducts()
    {
       return pluginClass.CallStatic<AndroidJavaOject>("getProductList");
    }
