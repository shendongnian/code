        public static int GetQuestionIDbyTekst(string question)
		{
			using (var context = new EfDbContext())
			{
				var test = new SqlParameter("@Tekst", question);
				var resultParam = new SqlParameter("@result", SqlDbType.Int);
				resultParam.Direction = ParameterDirection.Output;
				context.Database.ExecuteSqlCommand("exec @result = [dbo].[testProc] @Tekst", resultParam, test);
				return (int)resultParam.Value;
			}
		}
