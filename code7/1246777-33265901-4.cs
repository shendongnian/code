    public void Map(MyModelDto source, out MyModelView target)
    {
        target = new MyModelView {
             Prop1 = source.Prop1
        };
    }
