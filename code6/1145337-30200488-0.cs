    <table class="table" style="margin-bottom: 0px">
            <tbody>
                @for (var i = 0; i < Model.Count(); i++)
                {
                    <tr>
                        <td>
                            <input type="checkbox" name="ints" value=Model[i].ApplicationID />
                        </td>
                    <td>
                        @Html.ActionLink(Model[i].ApplicationID, "ViewApplication", new { ID = Model[i].ApplicationID, edit = 1 }, new AjaxOptions { HttpMethod = "GET" })
                    </td>
                    <td>
                        @Convert.ToDateTime(Model[i].ApplicationDate).ToString("M/d/yy")
                    </td>
                    <td>
                        @Model[i].ApplicantName
                    </td>
        </tbody>
    </table>
