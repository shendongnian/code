     for (int i = 0; i < Model.listModel.Count; i++)
        {
              @Html.TextBoxFor(modelItem => Model.listModel[i].LastName)    
        
            for (int m = 0; m < Model.listModel[i].anotherListObj.Count; m++)
            {
                  @Html.TextBoxFor(modelItem => Model.listModel[i].anotherListObj[m].FirstName)
            }
        }
