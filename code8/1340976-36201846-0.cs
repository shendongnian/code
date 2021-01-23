    using Dapper;
    using Dapper.Contrib.Extensions;
    // don't forget the using since Update is an extension method
    Dog entity; // you got it from somewhere
    entity.Name = "fancy new dog name";
    connection.Update(entity);
