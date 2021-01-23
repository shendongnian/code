     .Model(model =>
            {
                model.Id(p => p.Id);
                model.Field(p => p.Id).Editable(false);
                model.Field(p => p.UserName).Editable(false);
            })
