    @model PagedList.IPagedList<UploadItem>
    @using test1.Models;
    @using PagedList.Mvc;
    @using PagedList;
    @foreach (UploadItem item in Model)
    {
        @Html.Partial("_UploadSingleItem", item)
    }
