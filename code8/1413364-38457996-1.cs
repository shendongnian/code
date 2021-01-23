	//Program Table
	//Title Field
    modelBuilder.Entity<Anime>()
			    .Property(t => t.Title)
			    .HasColumnType("varchar")
			    .HasMaxLength(120) //define some Length..
			    .IsRequired(); //Will be translated as Not Null
	//CommentAnime
	//Opinion Field
    modelBuilder.Entity<CommentAnime>()
			    .Property(t => t.Opinion)
			    .HasColumnType("varchar")
			    .HasMaxLength(120) //define some Length..
			    .IsRequired(); //Will be translated as Not Null
	
	//Configuring the One-to-Many Relationship
	
	modelBuilder.Entity<CommentAnime>()
                .HasRequired(t => t.Anime)
                .WithMany(x => x.Comments)
                .HasForeignKey(t => t.AnimeId);
