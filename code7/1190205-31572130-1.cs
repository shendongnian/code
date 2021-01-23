    private Services ToService(string str)
    {
        return (Services)Enum.Parse(typeof(Services), str);
    }
    ...
    var result = members.Select(member => new 
        {
            member.Identifier, 
            Services = members.Services.Select(ToService)
        });
