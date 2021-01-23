    @for (int i=0; i<Model.ItemList.Count; i++)
        {
            @Html.HiddenFor(modelItem => modelItem.ItemList[i].Document.CRMDocumentId)
    
            <tr>
                <td>
                    @Html.EditorFor(modelItem => modelItem.ItemList[i].IsChecked)
                    @Html.ValidationMessageFor(modelItem => modelItem.ItemList[i].IsChecked)
                </td>
         
            </tr>
        }
