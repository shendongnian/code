    public MyModelView Map(MyModelDto source)
    {
        return new MyModelView{
             Prop1 = source.Prop1
        };
    }
