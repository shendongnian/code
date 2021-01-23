    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using Visio = Microsoft.Office.Interop.Visio;
    
    
    class Program
    {
        static void Main(string[] args)
        {
            //create the object that will do the drawing
            VisioDrawer Drawer = new VisioDrawer();
            Drawer.selectShpLayer("cool");
    
        }
    }
    
    class VisioDrawer
    {
        public Visio.Application VisApp;
        public static Visio.Page acPage;
        public Visio.Selection LayerSelection;
        public VisioDrawer()
        {
    
            //create the application
            VisApp = new Visio.Application();
            VisApp.Documents.Open(@"c:\temp\trial.vsdm");
            acPage = VisApp.ActivePage;
        }
    
    
    
        public void selectShpLayer(string layerName)
        {
            int i = 0;
            int[] lngRowIDs;
            Array lngRowIDArray;
            //this selects the shapes of the selected layer
            LayerSelection = acPage.CreateSelection(Microsoft.Office.Interop.Visio.VisSelectionTypes.visSelTypeByLayer, Microsoft.Office.Interop.Visio.VisSelectMode.visSelModeSkipSuper, layerName);
            LayerSelection.GetIDs(out lngRowIDArray);
            lngRowIDs = (int[])lngRowIDArray;
            for (i = 0; i < lngRowIDs.Length; i++)
            {
                Debug.Write("Object ID: " + lngRowIDs[i].ToString() + "\n");
            }
        }
    }
