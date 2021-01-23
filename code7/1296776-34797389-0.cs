      modelBuilder.Entity<TopicNewsModel>()
                        .HasRequired(topicNews => topicNews.NewsArticle)
                        .WithMany(news => news.Topics)
                        .Map(m => m.MapKey("id"));
            modelBuilder.Entity<TopicNewsModel>()
                        .HasRequired(topicNews => topicNews.Topic)
                        .WithMany()
                        .Map(m => m.MapKey("topicId"));
