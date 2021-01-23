    private static int Main(string[] args)
    {
        string line= "<H2:H2LabelComboBoxCell ID=\"LabelComboboxCellProject\"  SecurityID=\"CD4D3959-0ADB-4375-8DCF-917157528BDE\"/>";
        string stringToFind = "ID=\"";
        int firstQuote = line.IndexOf(stringToFind) + stringToFind.Length;
        int nextQuote  = line.IndexOf("\"",firstQuote);
        string id= line.Substring(firstQuote,nextQuote-firstQuote);
    
        System.Console.Write("id="+id);
        return 0;
    }
