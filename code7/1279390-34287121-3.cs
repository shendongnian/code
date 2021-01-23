	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;
	using Microsoft.SqlServer.TransactSql.ScriptDom;
	namespace ConsoleApplication8
	{
		public class QueryParser
		{
			public IEnumerable<string> Parse(string sqlSelect)
			{
				TSql100Parser parser = new TSql100Parser(false);
				TextReader rd = new StringReader(sqlSelect);
				IList<ParseError> errors;
				var columns = new List<string>();
				var fragments = parser.Parse(rd, out errors);
				var columnVisitor = new SQLVisitor();
				fragments.Accept(columnVisitor);
				columns = new List<string>(columnVisitor.Columns);
				return columns;
			}
		}
		internal class SQLVisitor : TSqlFragmentVisitor
		{
			private List<string> columns = new List<string>();
			private string GetNodeTokenText(TSqlFragment fragment) 
			{ 
				StringBuilder tokenText = new StringBuilder(); 
				for (int counter = fragment.FirstTokenIndex; counter <= fragment.LastTokenIndex; counter++) 
				{ 
					tokenText.Append(fragment.ScriptTokenStream[counter].Text); 
				}
				return tokenText.ToString(); 
			}
			
			public override void ExplicitVisit(ColumnReferenceExpression node)
			{
				columns.Add(GetNodeTokenText(node));
			}
			public IEnumerable<string>  Columns {
				get { return columns; }
			}
		} 
		public class Program
		{
			private static void Main(string[] args)
			{
				QueryParser queryParser = new QueryParser();
				var columns = queryParser.Parse("SELECT A,[B],C,[D],E FROM T  WHERE isnumeric(col3) = 1 Order by Id desc");
				foreach (var column in columns)
				{
					Console.WriteLine(column);
				}
			}
		}
	}
