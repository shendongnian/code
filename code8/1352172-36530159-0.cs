     public string AddressString 
     { 
        get 
        { 
            return string.Format("{0} {1} {2} {3}",
                  Street, !string.IsNullOrWhiteSpace(City) ? City + "," : "",
                  State, PostalCode);
        }
    }
