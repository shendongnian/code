    var model = definition.Settings.GetModel<AnimalTypePart>();
    model.AvailableValues = Enum.GetValues(typeof (AnimalEnum))
            .Cast<int>()
            .Select(i => 
                new {
                    Text = Enum.GetName(typeof (AnimalEnum), i), 
                    Value = i,
                    Selected = i == (int)model.Animal
                });
