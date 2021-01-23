    @{
       var imageName = Mission.UI.Areas.Cpanel.Components.Utility.GetDocument(Model.EmployeeId, Mission.Model.DocType.Aks);
       if(!string.IsNullOrEmpty(imageName))
       {
          string imagePath = @"/files/" + imageName;
        
          <div class="col-lg-4">
             <label style="display:block;">عکس</label><img src="@imagePath" 
                    class="thumbnail col-lg-12" style="height:280px;" />
          </div>
       }
    }
