    @model My.PageModel
    
    @My.CustomControl(new CustomControlModel
        {
            AreaTitle = "Details",
            RenderSideContent =
                @<div>
                    @using (My.CustomWrapper("General"))
                    {
                        My.BasicControl(Model.Controls[0])
                    }
                </div>
        })
