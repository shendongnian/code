    @{
       var imageName = Mission.UI.Areas.Cpanel.Components.Utility.GetDocument(Model.EmployeeId, Mission.Model.DocType.Aks);
    }
    @if(!string.IsNullOrEmpty(imageName))
    {
    <div class="col-lg-4">
        <label style="display:block;">عکس</label><img src="/files/@{imageName}" class="thumbnail col-lg-12" style="height:280px;" />
    </div>
    }
