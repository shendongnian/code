    [HttpPost]
    public AjaxResult DoAjaxWork(AjaxModel model)
    {
        if (model == null)
        {
            return new AjaxResult
            {
                AllowGet = false,
                Completed = false,
                Message = "The model is null",
            };
        }
        if (!ModelState.IsValid)
        {
            var error = this.ModelState.FirstOrDefault(x => x.Value.Errors.Count > 0).Value.Errors.First().ErrorMessage;
            return new AjaxResult
            {
                AllowGet = false,
                Message = error,
                Completed = false
            };
        }
        return new AjaxResult { Completed = true };
    }
