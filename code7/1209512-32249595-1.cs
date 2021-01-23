     ReportDocument reportDocument = new ReportDocument();
    
        ParameterField paramField = new ParameterField();
    
        ParameterFields paramFields = new ParameterFields();
    
    for (int i = 0; i < reportDocument.ReportDefinition.ReportObjects.Count; i++)
            {
                TextObject MyText = (TextObject)reportDocument.ReportDefinition.ReportObjects[i];
    
                MyText.ApplyFont(new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold));
    
                
            }
