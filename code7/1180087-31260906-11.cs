    @model WebApplication1.Controllers.MainModel
    @using (Html.BeginForm("PostDatas","Home"))
    {
        for (var i = 0; i < Model.CheckBoxes.Count; i++)
        {
            <table>
                <tr>
                    <td>
                        @Html.HiddenFor(m => Model.CheckBoxes[i].Id)
                        @Html.HiddenFor(m => Model.CheckBoxes[i].Name)
                        @Html.CheckBoxFor(m => Model.CheckBoxes[i].Checked)
                    </td>
                    <td>
                        @Html.DisplayFor(m => Model.CheckBoxes[i].Name)                    
                    </td>
                </tr>
            </table>
    
        }
        <input id="submit" type="submit" value="submit" />
    }
