            var ids = otherObjects.Select(i => i.Id);
            // When
            var results = repository.GetAll()
                .Where(a => ids.Contains(a.Id))
                .ToList()
                .Join(otherObjects, a => a.Id, b => b.Id, (a, b) => new SimpleDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Attribute = b.Attribute
                })
                .ToList();
