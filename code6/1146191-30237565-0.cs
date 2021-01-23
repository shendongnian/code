    using System;  
    using Weird;  
    public class WAddon : IAddon  
    {  
        public void Load(ResourceManager resManager)  
        {  
            resManager.add("var", "24");  
        }  
    }
