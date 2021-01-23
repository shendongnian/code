    var MockSet = new Mock<DbSet<T>>();
    MockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(MockData.AsQueryable().Provider);
    MockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(MockData.AsQueryable().Expression);
    MockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(MockData.AsQueryable().ElementType);
    MockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => MockData.AsQueryable().GetEnumerator());
    MockSet.Setup(m => m.Add(It.IsAny<T>())).Callback<T>(MockData.AddPlus); // here change te method 'Add' for the extension method 'AddPlus'
----------
    public static void AddPlus<T>(this List<T> miLista, T item) 
            {
                int nuevoId;
                int? id;
                try
                {
                    id = (int)item.GetPropValue("id");
                }
                catch
                {
                    id = null;
                }
                if (id == 0)
                {
                    if (miLista.Count() > 0)
                    {
                        var listaInts = miLista.Select(i => (int)i.GetPropValue("id"));
                        nuevoId = listaInts.Max(x=>x) + 1;
                    }
                    else
                        nuevoId = 1;
                    item.SetPropValue("id",nuevoId);
                }
                miLista.Add(item);
            }
