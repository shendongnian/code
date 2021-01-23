    public async Task SaveEntities(IEnumerable<Library2Book> library2Books)
            {
                    int i = 0;
                    foreach (var library2Book in library2Books)
                    {
                        _dbContext.Set<Library>().Add(codConc2Coding.Library);
                        _dbContext.Set<Book>().Add(codConc2Coding.Book);
                        _dbContext.Set<Library2Book>().Add(library2Book);
                        i++;
                        if (i == 99)
                        {
                            await _dbContext.SaveChangesAsync();
                            i = 0;
                        }
                    }
                    await _dbContext.SaveChangesAsync();
    }
