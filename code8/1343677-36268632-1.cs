    string line = "He: 4.002602 amu";
    
    int intLspacePos = line.IndexOf(" ") + 1;
    int intRspacePos = line.LastIndexOf(" ");
    
    string strNumber = line.Substring(intLspacePos, intRspacePos - intLspacePos);
    double dblNumber = Convert.ToDouble(strNumber);
