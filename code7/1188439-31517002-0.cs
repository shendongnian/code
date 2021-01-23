    var model = new TestModel
            {
                Categories = _repository.Categories.Select(c => new CategoryModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
            };
