     modelBuilder.Entity<Message>()
                       .HasMany<Tag>(m => m.Tags)
                       .WithMany(t => t.Messages)
                       .Map(mt =>
                                {
                                    mt.MapLeftKey("MessageID");
                                    mt.MapRightKey("TagId");
                                    mt.ToTable("MessagesTag");  //Name of table many to many
                                });
