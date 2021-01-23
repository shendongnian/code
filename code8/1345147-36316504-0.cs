    private void SetContentDynamic(dynamic xmlElement)
    {
        //Defaults
        this.Title = XElementExtension.GetElementValue(xmlElement,"Title"); //This is where the error occurs
        //lots more code below
    }
