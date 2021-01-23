        private List<Entity> _entities = new List<Entity>();
        private void Form1_Load(object sender, EventArgs e)
        {
            _entities.Add(new Entity(1, "Continent", null));
            _entities.Add(new Entity(2, "Country", 1));
            _entities.Add(new Entity(3, "Province", 2));
            _entities.Add(new Entity(4, "City1", 3));
            _entities.Add(new Entity(5, "Suburb1", 6));
            _entities.Add(new Entity(6, "City2", 3));
            _entities.Add(new Entity(7, "Suburb2", 6));
            _entities.Add(new Entity(8, "Suburb3", 6));
            _entities.Add(new Entity(9, "Suburb4", 4));
            _entities.Add(new Entity(10, "House1", 7));
            _entities.Add(new Entity(11, "House3", 9));
            _entities.Add(new Entity(12, "House4", 8));
            _entities.Add(new Entity(13, "House5", 8));
            _entities.Add(new Entity(14, "House6", 7));
            var parent = _entities.Find((x) => x.ParentId == 0);
            EnumerateChildren(parent, 1);
        }
        private void EnumerateChildren(Entity thisEntity, int level)
        {
            Debug.WriteLine(new string('-', level) + thisEntity.Name);
            foreach (var child in _entities.FindAll((x) => x.ParentId == thisEntity.Id).OrderBy(x => x.Id))
            {
                EnumerateChildren(child, level + 1);
            }
        }
        private class Entity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ParentId { get; set; }
            public Entity(int id, string name, int? parentId)
            {
                this.Id = id;
                this.ParentId = parentId.HasValue ? Convert.ToInt32(parentId) : 0;
                this.Name = name;
            }
        }
