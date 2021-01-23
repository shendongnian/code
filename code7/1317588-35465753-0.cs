    int number = 15;
    double dub = 15.5;
    Button button = new Button();
    Dictionary<object, Type> typeGlossary = new Dictionary<object, Type>();
    typeGlossary.Add(number, typeof(int));
    typeGlossary.Add(dub, typeof(double));
    typeGlossary.Add(button, typeof(Button));
