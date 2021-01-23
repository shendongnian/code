	void Main()
	{
		Person Item = UsingPerson(ps => ps.Where(x => x.Age < 40).Take(1)).FirstOrDefault();
	}
	
	
	public T[] UsingPerson<T>(Func<IQueryable<Person>, IQueryable<T>> project)
	{
		using (myEntities ctx = new myEntities())
		{
			return project(ctx.Person.Where(x => x.Age < 50)).ToArray();
		}
	}
