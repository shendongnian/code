    using VBA = Microsoft.Vbe.Interop;
    using Excel = Microsoft.Office.Interop.Excel;
    private void ExecuteMacro()
    {
    	string filePath = @"C:\temp\Macro.xlsm";
    
    	Microsoft.Office.Interop.Excel.Application appExcel = null;
    	Microsoft.Office.Interop.Excel.Workbooks workbooks = null;
    	Microsoft.Office.Interop.Excel.Workbook workbook = null;
    
    	object oMiss = System.Reflection.Missing.Value;
    
    	appExcel = new Microsoft.Office.Interop.Excel.Application();
    	// Make the excel visible
    	appExcel.Visible = true;
    	workbooks = appExcel.Workbooks;
    	workbook = workbooks.Open(filePath, oMiss,
    							  oMiss, oMiss,
    							  oMiss, oMiss,
    							  oMiss, oMiss,
    							  oMiss, oMiss,
    							  oMiss, oMiss,
    							  oMiss, oMiss,
    							  oMiss);
    
    	var project = workbook.VBProject;
    	var comps = project.VBComponents;
    	
    	var procedureType = VBA.vbext_ProcKind.vbext_pk_Proc;
    	List<string> macroNames = new List<string>();
    	// 1. Check names of macro in the workbook
    	foreach (var component in comps)
    	{
    		VBA.VBComponent vbComponent = component as VBA.VBComponent;
    		if (vbComponent != null)
    		{
    			string componentName = vbComponent.Name;
    			var componentCode = vbComponent.CodeModule;
    			int componentCodeLines = componentCode.CountOfLines;
    			int line = 1;
    			while (line < componentCodeLines)
    			{
    				string procedureName = componentCode.get_ProcOfLine(line, out procedureType);
    				if ((!string.IsNullOrEmpty(procedureName))&&(!macroNames.Contains(procedureName)))
    				{
    					macroNames.Add(procedureName);
    				}
    				line++;
    			}
    		}
    	}
    	foreach (var macro in macroNames)
    	{
    		// 2. Prompt user if he wants to enable the macro.
    		var result = MessageBox.Show(string.Format("Would you like to execute {0} ?", macro), "", MessageBoxButtons.YesNo);
    		if (result == DialogResult.Yes)
    		{
    			// 3. If yes, enable the macro for user.
    			appExcel.Run(macro,
    					oMiss, oMiss, oMiss, oMiss, oMiss,
    					oMiss, oMiss, oMiss, oMiss, oMiss,
    					oMiss, oMiss, oMiss, oMiss, oMiss,
    					oMiss, oMiss, oMiss, oMiss, oMiss,
    					oMiss, oMiss, oMiss, oMiss, oMiss,
    					oMiss, oMiss, oMiss, oMiss, oMiss);
    
    		}
    	}
    	workbook.Close(true, oMiss, oMiss);
    
    	System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
    	workbook = null;
    	System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
    	workbooks = null;
    	appExcel.Quit();
    	System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
    	appExcel = null;
    }
