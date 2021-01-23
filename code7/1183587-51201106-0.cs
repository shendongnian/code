	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using System.Text.RegularExpressions;
	using LookupExample.Data;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	namespace LookupExample.Areas.Admin.Controllers
	{
		// [Authorize]
		[Area("Admin")]
		public class SetupController : Controller
		{
			private ApplicationDbContext _db;
			public SetupController(ApplicationDbContext dbContext)
			{
				_db = dbContext;
			}
			public IActionResult Enums()
			{
				var enums = Assembly.GetExecutingAssembly().GetTypes()
					.Where(ttype => ttype.IsEnum && ttype.IsPublic && ttype.Namespace.StartsWith("LookupExample.Models"));
				var dictionary = enums.ToDictionary(EnumTableName, EnumDictionary);
				if (dictionary.Count <= 0) return Json(dictionary);
	#pragma warning disable EF1000 // Possible SQL injection vulnerability.
				foreach (var kvp in dictionary)
				{
					var table = kvp.Key;
					var tableSql = $"IF OBJECT_ID('{table}', 'U') IS NOT NULL DROP TABLE {table}; CREATE TABLE {table} ( Id int, Val varchar(255));";
					_db.Database.ExecuteSqlCommand(tableSql);
					if (kvp.Value.Count <= 0) continue;
					var insertSql = $"INSERT INTO {table} (Id, Val) VALUES ( @P0, @P1);";
					foreach (var row in kvp.Value)
					{
						_db.Database.ExecuteSqlCommand(insertSql, row.Key, row.Value);
					}
				}
	#pragma warning restore EF1000 // Possible SQL injection vulnerability.
				return Json(dictionary);
			}
			private string EnumTableName(Type eenum)
			{
				var namespaceModifier = Regex.Replace(Regex.Replace(eenum.Namespace, @"^LookupExample\.Models\.?", ""), @"\.?Enums$", "").Replace(".", "_");
				if (namespaceModifier.Length > 0)
				{
					namespaceModifier = namespaceModifier + "_";
				}
				return "dbo.Enum_" + namespaceModifier + eenum.Name; // TODO enum schema?
			}
			private Dictionary<int, string> EnumDictionary(Type eenum)
			{
				return Enum.GetValues(eenum).Cast<int>().ToDictionary(e => e, e => Enum.GetName(eenum, e));
			}
		}
	}
