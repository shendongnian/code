    public Network(SerializationInfo info, StreamingContext context)
    {
        this.MyComponents = (List<Component>)info.GetValue("MyComponents", MyComponents.GetType());
        this.Pipelines = (List<Pipeline>)info.GetValue("Pipelines", Pipelines.GetType());
    }
