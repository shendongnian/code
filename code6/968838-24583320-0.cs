    _genericDataReader
        .Stub(gdr => gdr.ExecuteSqlQuery(Arg<List<IDataParameter>>.Is.Anything, Arg<CommandTypeEnum>.Is.Anything, Arg<string>.Is.Anything))
        .Do((Func<List<IDataParameter>, CommandTypeEnum, string, IDictionary<long, ITrade>>)((param, cmd, cmdName) =>
        {
            param[3].Value = 12L;
            return null; // or return whatever is required dataset here
        }));
