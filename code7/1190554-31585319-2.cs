    @using WebApplication100.Models
    @model StudentMarkAssignViewModel[]
    @using (Html.BeginForm("Add", "StudentMarks", FormMethod.Post))
    {
        <table>
            @for (var index = 0; index < Model.Length; index++)
            {
                <tr>
                    @Html.HiddenFor(x => Model[index].StudentId)
                    @Html.HiddenFor(x => Model[index].FullName)
                    <td>@Model[index].FullName</td>
                    <td>
                        @Html.DropDownListFor(x => Model[index].Mark, new SelectListItem[]{
                            new SelectListItem{ Value = "0", Text = "Not Rated", Selected = Model[index].Mark == 0  } ,
                            new SelectListItem{ Value = "5", Text = "5"  , Selected = Model[index].Mark == 5  } ,
                            new SelectListItem{ Value = "4.75", Text = "4+"  , Selected = Model[index].Mark == 4.75  }
                   })
                    </td>
                </tr>
            }
        </table>
        <button type="submit">submit</button>
    }
