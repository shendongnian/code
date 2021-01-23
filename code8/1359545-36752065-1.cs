        public Mock<IRepository<T>> MockRepository<T>() where T : BaseEntity<int> //(for Id )
        {
            var repository = new Mock<IRepository<T>>();
            var entities = new List<T>(); // Add variables to be used in the setups
            repository.Setup(x => x.GetAll()).Returns(entities.AsQueryable());
            repository.Setup(x => x.GetById(It.IsAny<int>())).Returns<int>(id => entities.Find(c => c.Id == id));
            repository.Setup(x => x.Add(It.IsAny<T>())).Callback<T>(c => entities.Add(c));
            repository.Setup(x => x.Delete(It.IsAny<T>())).Callback<T>(c => entities.Remove(c));
    ...
    return repository;
        }
