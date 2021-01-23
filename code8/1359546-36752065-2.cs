          public Mock<IRepository<T,TKey>> MockRepository<T, TKey>() where T : BaseEntity<TKey> //(for Id )
        {
            var repository = new Mock<IRepository<T>>();
            var entities = new List<T>(); // Add variables to be used in the setups
            repository.Setup(x => x.GetAll()).Returns(entities.AsQueryable());
            repository.Setup(x => x.GetById(It.IsAny<TKey>())).Returns<TKey>(id => entities.Find(c => c.Id == id));
            repository.Setup(x => x.Add(It.IsAny<T>())).Callback<T>(c => entities.Add(c));
            repository.Setup(x => x.Delete(It.IsAny<T>())).Callback<T>(c => entities.Remove(c));
