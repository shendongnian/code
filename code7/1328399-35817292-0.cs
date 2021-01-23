    public DB Where(string field, string operat, string value, string andOr, string field2, string operat2, string value2)
    {
        string[] inputs = {field, operat, value, andOr, field2, operat2, value2}
        if (inputs.Any(x => string.IsNullOrWhiteSpace(x))){
            //throw exception
        }
        //continue with your method, all inputs are OK
    }
