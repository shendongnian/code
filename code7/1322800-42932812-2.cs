	using Microsoft.EntityFrameworkCore.Infrastructure;
	using Microsoft.EntityFrameworkCore.Internal;
	using Microsoft.EntityFrameworkCore.Storage;
	using System.Threading;
	using System.Threading.Tasks;
	namespace Microsoft.EntityFrameworkCore
	{
		public static class RDFacadeExtensions
		{
			public static RelationalDataReader ExecuteSqlQuery(this DatabaseFacade databaseFacade, string sql, params object[] parameters)
			{
				var concurrencyDetector = databaseFacade.GetService<IConcurrencyDetector>();
				using (concurrencyDetector.EnterCriticalSection())
				{
					var rawSqlCommand = databaseFacade
						.GetService<IRawSqlCommandBuilder>()
						.Build(sql, parameters);
					return rawSqlCommand
						.RelationalCommand
						.ExecuteReader(
							databaseFacade.GetService<IRelationalConnection>(),
							parameterValues: rawSqlCommand.ParameterValues);
				}
			}
			public static async Task<RelationalDataReader> ExecuteSqlQueryAsync(this DatabaseFacade databaseFacade, 
																 string sql, 
																 CancellationToken cancellationToken = default(CancellationToken),
																 params object[] parameters)
			{
				var concurrencyDetector = databaseFacade.GetService<IConcurrencyDetector>();
				using (concurrencyDetector.EnterCriticalSection())
				{
					var rawSqlCommand = databaseFacade
						.GetService<IRawSqlCommandBuilder>()
						.Build(sql, parameters);
					return await rawSqlCommand
						.RelationalCommand
						.ExecuteReaderAsync(
							databaseFacade.GetService<IRelationalConnection>(),
							parameterValues: rawSqlCommand.ParameterValues,
							cancellationToken: cancellationToken);
				}
			}
		}
	}
