    public static AjaxResult Failed(ModelStateDictionary modelState, string titleMessage = "", bool allowGet = false)
    {
        StringBuilder errorBuilder = new StringBuilder();
        if (!string.IsNullOrEmpty(titleMessage))
            errorBuilder.AppendLine(titleMessage);
    
        modelState.Where(x => x.Value.Errors != null && x.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors).ToList().ForEach(e =>
        {
            string errorLine = null;
            if (e.ErrorMessage != null)
                errorLine = string.Concat("", e.ErrorMessage);
            if (e.Exception != null)
                errorLine = string.Concat(errorLine, "Exception:", e.Exception.Message);
            errorBuilder.Append(errorLine);
        });
    
        return new AjaxResult
        {
            Completed = false,
            StatusCode = 200, //Your call here.. 200 = check completed flag, else handle it in the error handler
            AllowGet = false,
            Data = null,
            Message = errorBuilder.ToString()
        };
    }
