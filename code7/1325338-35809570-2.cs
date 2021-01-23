    @model AssignPatrolViewModel
    ....
    @using (Html.BeginForm())
    {
        @Html.LabelFor(m => m.SelectedPatrol)
        @Html.DropDownListFor(m => m.SelectedPatrol, Model.PatrolList, "Please select")
        @Html.ValidationMessageFor(m => m.SelectedPatrol)
        <table>
            .... // thead elements
            <tbody>
                @for(int i = 0; i < Model.Members.Count; i++)
                {
                    <tr>
                        <td>
                            @Html.CheckBoxFor(m => m.Members[i].IsSelected)
                            @Html.HiddenFor(m => m.Members[i].MemberId)
                            // add other hidden inputs for properties you want to post
                        </td>
                        <td>@Html.DisplayFor(m => m.Members[i].FirstName)</td>
                        ....
                    </tr>
                }
            </tbody>
        </table>
        <input type="submit" value="Assign" class="btn btn-success" />
    }
