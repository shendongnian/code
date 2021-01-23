    int rowNum = 13;
    while(reader.Read())
    {
        pdfFormFields.SetField("PROFLIABILITYCARRIERpg" + rowNum.ToString(), reader.GetValue(4).ToString()); 
        pdfFormFields.SetField("PROFLIABILITYCARRIER2pg" + rowNum.ToString(), reader.GetValue(4).ToString()); 
        pdfFormFields.SetField("POLICYNUMBERpg" + rowNum.ToString(), reader.GetValue(5).ToString()); 
    
        rowNum++;
    }
