        @model WhiteBoardApp.Models.UserProfile
        
        @using (Html.BeginForm("DeleteUser", "Account"))
        {
            @Html.AntiForgeryToken()
            @Html.ValidationSummary()
        
            <fieldset>
                <div class="container-fluid">
                    <ol>
                        <li>
        
                            @Html.LabelFor(m => m.UserName)
                            @Html.DropDownListFor(m => m.UserName, new SelectList(GetUserName(), "UserName", "UserName"))
                            <span style="color:red;">@TempData["ErrorMessage"]</span>
                        </li>
        
                    </ol>
                    <input type="submit" value="Delete User" />
                    </div>
        </fieldset>
        }
