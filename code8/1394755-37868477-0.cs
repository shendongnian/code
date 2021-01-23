        public class KendoTreeViewItem 
        { 
            //required properties:
            //property names are lower case because I am planning to convert to   
         //javascript array and at that point kendo is looking for lower case   properties.
          public string id { get; set; }
          public bool expanded { get; set; }
          public bool @checked{get; set; }
          public IList<KendoTreeViewItem> Items{get;set;}
          public string text{ get; set; }
          public bool hasChildren{get;set;}
          public bool hasChildren{get;set;} 
           //Add other custom properties         
        }
