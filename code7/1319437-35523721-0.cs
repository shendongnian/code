    @model System.Collections.Generic.List<Restaurant>
    
    @{
        foreach (var restaurant in Model) {
            Html.RenderAction("Child", "Restaurants", restaurant);
        }
    }
