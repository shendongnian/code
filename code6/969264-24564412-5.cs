    Blah.Clear();
    
    for (var i = 0; i < SelectedAttribute.Categories.Count; i++) {
       Blahs.Add(new SomeGridItem() {
            Category = SelectedAttribute.Categories[i],
            SecondProp = SelectedAttribute.SecondCollection[i],
            ThirdProp = SelectedAttribute.ThirdCollection[i]
        });
    }
