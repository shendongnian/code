    using System.Collections.Generic;
    public AndroidJavaOject getProducts()
    {
       return pluginClass.CallStatic<AndroidJavaOject>("getProductList");
    }
