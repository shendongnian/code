    private bool IsStringBuilderNullOrEmpty(StringBuilder sb) {
        return sb == null || sb.Length == 0 || string.IsNullOrWhiteSpace(sb.ToString());
    }
    //text examples
    StringBuilder test = null;
    Console.WriteLine(IsStringBuilderNullOrEmpty(test));//true
    
    
    StringBuilder test = new StringBuilder();
    test.Append("");
    
    Console.WriteLine(IsStringBuilderNullOrEmpty(test));//true
    
    StringBuilder test = new StringBuilder();
    test.Append("hello there");
    
    Console.WriteLine(IsStringBuilderNullOrEmpty(test));//false
