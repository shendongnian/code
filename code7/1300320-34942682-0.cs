    string sb="";
    var formlist = new list<string>();
    foreach(var c in calc.CalculationFormula)
    {
        sb = sb + c;
        if(delimstringlist.Contains(sb))
        {
            formlist.Add(sb);
            sb = "";
        }
        else if(formulaSplit.Contains(sb))
        {
            formlist.Add(sb);
            sb = "";
        }
    }
