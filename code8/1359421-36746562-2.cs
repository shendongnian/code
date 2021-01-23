    for (var i = 0; i < Model.Answers.Count; i++)
    {
        if (Model.Answers[i].IsActive)
        {
            <div class="form-group answer">
                <div class="col-md-10">
                    @Html.HiddenFor(m => Model.Answers[i].Id)
                    @Html.TextBoxFor(m => Model.Answers[i].Answer, new { @class = "form-control" })
                    @Html.ValidationMessageFor(m => Model.Answers[i].Answer, null, new { @class = "text-danger" })
                </div>
                <div class="col-md-2">
                    @Html.CheckBoxFor(m => Model.Answers[i].IsActive)
               </div>
           </div>
        }
    }
