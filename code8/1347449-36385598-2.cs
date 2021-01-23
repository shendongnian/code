    @Html.DropDownListFor(model => model.Selected, Model.Restaurants.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString(),
                Selected = r.Id == Model.Restaurants.Count
            }));
