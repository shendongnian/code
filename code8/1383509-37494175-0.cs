    @foreach (var c in Model)
    {
        <tr>
            ....
            <td>
                @using (Html.BeginForm("DisableUser", "UserManagement", new { id = c.UserId ))
                {
                    <input type="submit" value="Disable" class="btn btn-primary"/>
                }
            </td>
        </tr>
    }
