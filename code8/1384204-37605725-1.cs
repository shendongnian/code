    for(int i = 0; i < Model.ProductAssetAudios.Count; i++)
    {
        @Html.TextBoxFor(m => m.ProductAssetAudios[i].SomeProperty)
        ....
        for (int j = 0; j < Model.ProductAssetAudios[i].ProductAssetResources.Count; j++)
        {
            @Html.DropDownListFor(m => m.ProductAssetAudios[i].ProductAssetResources[j].AssetResourceStatusId, new SelectList(.....)
