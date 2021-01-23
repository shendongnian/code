	public class WhateverClass<T>
		where T : IDeletable
    {
		public List<T> GetAll()
		{
			return context.Set<T>().Where(p => p.deletion_date == null).ToList();
		}
	}
