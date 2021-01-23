    @for (var c = 0; c < Model.ExistingGroups.Count; c++)
         {
          @using (Html.BeginForm("EditGroup", "Group", new { id = Model.Id.StripCollectionName(), slug = Model.Slug, innerid = Model.ExistingGroups[c].Id }, FormMethod.Post, new { id = "editcommunityteamform" + c.ToString(CultureInfo.InvariantCulture), @class = "nomarginbottom" }))                                    
          {
          ...
          @Html.DropDownList("Gender",  new SelectList(Model.CreateGroupForm.Genders, "Value", "Text", Model.ExistingGroups[c].Gender))
         ...
          }
         }
