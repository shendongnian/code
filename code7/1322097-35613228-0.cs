    public string GeneratePartiesOptionsList()
    {
           //parties is a non-empty static readonly array of string[] type
            Debug.WriteLine("GeneratePartiesOptionsList() called");
            
            return string.Join(
                Environment.NewLine
                parties.Select(
                   party => 
                    string.Format("<option value='{0}'>{0}</option>", party));
    }
