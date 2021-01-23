       public partial class ThisAddIn
    {
            public Microsoft.Office.Interop.Outlook.Inspectors _inspector;
    
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
    		    _inspector = this.Application.Inspectors;
                _inspector.NewInspector += new InspectorsEvents_NewInspectorEventHandler(Custom_Inspector);
    		}
    		
    }
