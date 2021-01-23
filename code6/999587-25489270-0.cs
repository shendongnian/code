    //pass the zpl generated from Zebra Designer Pro into this menthod
    public string replaceParameterValues(string zplForLabel)
    {
        StringBuilder zpl = new StringBuilder();
        zpl.Apppend(zplForLabel);
        //do this for all the paramters
        zpl = zpl.Replace("<ParemeterName>", valueForTheParamter);
    
        //pass this zpl to the printer for printing as it will contain 
        //all the values for the parameters 
        return zpl.ToString();
    }
