    @model List<PGWebAdmin.Models.AppConfigViewModel>
    @{
        var itemCnt = 0;
    }
    @using (Html.BeginForm())
    {
      foreach (var item in Model)
      {
       
        <input type="hidden" name="[@itemCnt].Index" value="@itemCnt" />
        <input type="text" value="@item.Value" name="AppConfigViewModelInput[@itemCnt].Value"/>
        <input type="text" name="[@itemCnt].Setting" value="@item.Setting"/>
        itemCnt++;
      }
        <input type="submit" value="Save" class="btn btn-default" />
    }
