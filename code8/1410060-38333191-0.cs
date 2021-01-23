    public string GetRefNo(FormData formData)
    {
        foreach (var formFieldData in formFieldDataList)
        {
            try
            {
                this._formDataService.SubmitFormData(formFieldData);
            }
           catch (MyDatabaseLevelException exception)
           {
                //log or do something with this.
           }
        }
    }
