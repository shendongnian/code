    List<Parameter> parameters = new List<Parameter>();
    parameters.Add(Parameter.Create<int>(15));
    parameters.Add(Parameter.Create<float>(10F));
    int val1 = parameters[0].Get<int>();
    float val2 = parameters[1].Get<float>();
    // This will throw a InvalidCastException as intended
    double val3 = parameters[0].Get<double>();
