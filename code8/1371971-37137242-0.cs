    @foreach(var items in Model.EightWatseChkBox)
    {
           @Html.DisplayFor(model => items.Text)
           if(ViewBag.Chekboxlist != null)
           {
               IEnumerable<MyEntity> myEntity = (IEnumerable<MyEntity>)ViewBag.Chekboxlist;
               foreach(var item in myEntity )
               {
                   @Html.CheckBoxFor(model => item.Checked)
               }
          }   
    }
