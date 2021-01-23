     <div id="mainwrapper">
     @using (Html.BeginForm("// Action Name //", "// Controller Name //", FormMethod.Post, new { @id = "form1" }))
      {  
       @Html.TextBoxFor(m => m.RoleName)
       <input type="submit" value="Save"/>
      }
      <div id="RolesList">
       @if(Model!=null)
        {
          if(Model.Roleslist!=null)
          {
           foreach(var item in Model.Roleslist) //Just Populate Roleslist with values on controller side
           {
           //here item will have your values of RoleId and RoleName 
           }
          }
        }
      </div>
      </div>
