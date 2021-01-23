    Blah.Clear();
    
    for (var i = 0; i < SelectedAttribute.Categories.Count; i++) {
       Blahs.Add(new SomeGridItem() {
            Category = SelectedAttribute.Categories[i],
            SecondProp = SelectedAttribute.SecondProp[i],
            ThirdProp = SelectedAttribute.ThirdProp[i]
        }
    }
