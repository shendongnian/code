		using Microsoft.SqlServer.Server;
		using System;
		using System.Collections.Generic;
		using System.Data.SqlTypes;
		using System.Linq;
		using System.Text;
		using System.Text.RegularExpressions;
		using System.Threading.Tasks;
		
		public class StackOverflow
		{
			[SqlFunction(DataAccess = DataAccessKind.None, IsDeterministic = true, Name = "RegexReplace")]
			public static SqlString Replace(SqlString sqlInput, SqlString sqlPattern, SqlString sqlReplacement)
			{
				string input = (sqlInput.IsNull) ? string.Empty : sqlInput.Value;
				string pattern = (sqlPattern.IsNull) ? string.Empty : sqlPattern.Value;
				string replacement = (sqlReplacement.IsNull) ? string.Empty : sqlReplacement.Value;
				return new SqlString(Regex.Replace(input, pattern, replacement));
			}
		}
