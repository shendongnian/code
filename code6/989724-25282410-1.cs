    @model UploadItem
    @using test1.Models;
    @using PagedList.Mvc;
    @using PagedList;
    @using (Ajax.BeginForm("DeleteItem", "Upload", new AjaxOptions {HttpMethod = "POST"}))
    {
        @Html.HiddenFor(m => item.FileName)
        @Html.HiddenFor(m => item.Directory)
        <input type="submit" value="Delete" />
    }
