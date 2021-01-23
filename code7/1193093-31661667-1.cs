    @model YourNameSpace.Models.ViewModel
    
    @for(int i = 0; i < Model.DataFromController.Count(); i++){
        @Html.DropDownListFor(m => m.DataFromController[i].Assigner, Model.DropDownData)
    }
