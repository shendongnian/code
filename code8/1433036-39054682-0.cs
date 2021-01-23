    @using Microsoft.AspNetCore.Mvc.ModelBinding
    @if(ViewData.ModelState.GetFieldValidationState("Fragment.Content") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
    {
        //  something here
    }
