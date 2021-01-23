    using Neo4jRepository.Data.Model;
    using System.Threading.Tasks;
    
    namespace Neo4jRepository.Repository
    {
        public class BlogPostRepository : Neo4jRepository<BlogPost>
        {
            // any custom methods or overridden methods here
    
            /// <summary>
            /// Adds or updates a blog post.
            /// </summary>
            /// <param name="post">The post.</param>
            /// <returns></returns>
            public async Task AddOrUpdate(BlogPost post)
            {
                var found = await this.Single(p => p.Author == post.Author && p.Content == post.Content && p.Title == post.Title);
                if(found == null)
                {
                    await Add(post);
                }
                else
                {
                    await Update(p => p.Author == post.Author && p.Content == post.Content && p.Title == post.Title, post);
                }
            }
        }
    }
