     var carInstance = dbContext.Cars.First();
     carInstance.RowVersion = carDTO.RowVerison;
     carInstance.Color = carDTO.Color ;
     var entry = dbContext.Entry(carInstance); //Can also come from ChangeTrack in override of SaveChanges (to do it automatically)     
     entry.Property(e => e.RowVersion)
                        .OriginalValue = entry.Entity.RowVersion;
