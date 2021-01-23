    @Html.EditorFor(model => model.Location,
                 HtmlBuildersExtended.ConditionalReadonly((bool)ViewBag.CanEdit, 
                        new
                        {
                            htmlAttributes = new
                            {
                                @class = "form-control"
                            }
                        }));
