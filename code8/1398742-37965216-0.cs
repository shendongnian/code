    using System;
    using System.Reflection;
    
    public class DetailView
    {
         public string SiteName { get; set; }
            public string ItemType { get; set; }
            public string AssetStorage { get; set; }
    
       
    }
        public class Example
        {
            public static void Main()
            {
                DetailView fieldsInst = new DetailView();
                // Get the type of DetailView.
                Type fieldsType = typeof(DetailView);
           
    		PropertyInfo[] props = fieldsType.GetProperties(BindingFlags.Public 
                | BindingFlags.Instance);
            
         
    		for(int i = 0; i < props.Length; i++)
            {
                Console.WriteLine("   {0}",
                    props[i].Name);
            }
        }
    }
