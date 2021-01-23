    for (int i = 0; i < Model.Answers.Count(); i++)
    {
        if (Model.Answers[i].IsActive)
        {
            <div class="form-group answer">
                <div class="col-md-10">
                    @Html.HiddenFor(x => Model.Answers[i].Id)
                    @Html.TextBoxFor(x => Model.Answers[i].Answer, new { @class = "form-control" })
                    validation code will go here
                </div>
                <div class="col-md-2">
                    @Html.CheckBox(x => Model.Answers[i].IsActive)
               </div>
               @Html.ValidationMessageFor(m => x => Model.Answers[i].Answer, null, new { @class = "text-danger" })
           </div>
        }
    }
