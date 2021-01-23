    var filter = Builders<Book>.Filter.Or(
		Builders<Book>.Filter.Where(p=>p.Title.ToLower().Contains(query.ToLower())),
		Builders<Book>.Filter.Where(p => p.Publisher.ToLower().Contains(query.ToLower())),
		Builders<Book>.Filter.Where(p => p.Description.ToLower().Contains(query.ToLower()))
				);
	List<Book> books = Collection.Find(filter).ToList();
