    open Dapper.Extensions.Linq.Core.Configuration
    open Dapper.Extensions.Linq.Mapper
    open Dapper.Extensions.Linq.Sql
    open Dapper.Extensions.Linq.CastleWindsor
    
    DapperConfiguration.Use().UseClassMapper(typeof<AutoClassMapper<_>>).UseContainer<Dapper.Extensions.Linq.CastleWindsor.ContainerForWindsor>(fun c ->  c.UseExisting(_container)).UseSqlDialect(new SqlServerDialect()).FromAssembly("Dapper.Entities").Build()
