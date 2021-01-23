    private void DefineSecondClass()
    {
        var type = ProtoBuf.Meta.RuntimeTypeModel.Default.Add(
            typeof(TestClass2<string>), false);
        type.AddField(1, "TestField");
        type[1].DynamicType = true;
    }
