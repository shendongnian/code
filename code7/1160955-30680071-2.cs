    class a{
		public void getEntities(){
			 B b = new b();
			 List<entity> entities = b.Select(c=>c.id==5);
			 // more detail
		}
	}
	class b {
		pubic List<entity> Select(Func<entity, bool> expression){
			return _dbSet.Where(expression).ToList();
		}
	}
  
