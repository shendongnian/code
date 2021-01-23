    public MyNancyModule(IGetPersons personGetter)
    {
        Get["/"] = _ =>
        {
            var x = List<Person> personGetter.GetAll(); // Look, don't need to resolve this manually!
            return Response.AsJson(x);
        };
    }
