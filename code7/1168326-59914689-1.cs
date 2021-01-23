                var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, userId);
                if (!isTheFavoritesArrayNotNull)
                {
                    await collection.UpdateOneAsync(filter,
                        isFavorite ? Builders<UserEntity>.Update.Set(u => u.Favorites, new List<Favorite>()));
                }
                await collection.UpdateOneAsync(filter,
                        Builders<UserEntity>.Update.AddToSet(u => u.Favorites.ProgramIds, id));
 
