    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using GamerFootprint.Data.Models;
    using Neo4jClient;
    
    namespace Data.Repository
    {
        public class Neo4jRepository<TEntity> : IRepository<TEntity>
        where TEntity : Neo4jEntity, IEntity, new()
        {
            protected readonly GraphClient client;
    
            public Neo4jRepository()
            {
                client = new GraphClient(new Uri("http://localhost:7474/db/data"));
                client.Connect();
            }
    
            /// <summary>
            /// Gets all.
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity.</typeparam>
            /// <returns></returns>
            public virtual async Task<IEnumerable<TEntity>> All()
            {
                TEntity entity = new TEntity();
    
                return await client.Cypher
                    .Match("(e:" + entity.Label + ")")
                    .Return(e => e.As<TEntity>())
                    .ResultsAsync;
            }
    
            /// <summary>
            /// Finds a collection of entities with the specified query.
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity.</typeparam>
            /// <param name="query">The query.</param>
            /// <returns></returns>
            public virtual async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> query)
            {
                string name = query.Parameters[0].Name;
                TEntity entity = (TEntity)Activator.CreateInstance(query.Parameters[0].Type);
                Expression<Func<TEntity, bool>> newQuery = PredicateRewriter.Rewrite(query, "e");
    
                return await client.Cypher
                    .Match("(e:" + entity.Label + ")")
                    .Where(newQuery)
                    .Return(e => e.As<TEntity>())
                    .ResultsAsync;
            }
    
    
            /// <summary>
            /// Gets a single entity of type <typeparamref name="TEntity"/> with the specified query. <see cref="Neo4jRepository{TEntity}"/>
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity.</typeparam>
            /// <param name="query">The query.</param>
            /// <returns></returns>
            public virtual async Task<TEntity> Single(Expression<Func<TEntity, bool>> query)
            {
                IEnumerable<TEntity> results = await Where(query);
                return results.FirstOrDefault();
            }
    
            /// <summary>
            /// Adds a <see cref="TEntity"/>
            /// </summary>
            /// <typeparam name="TEntity"></typeparam>
            /// <param name="item"></param>
            public virtual void Add(TEntity item)
            {
                client.Cypher
                        .Create("(e:" + item.Label + " {item})")
                        .WithParam("item", item)
                        .ExecuteWithoutResults();
            }
    
            /// <summary>
            /// Updates an entity or entity set with the specified query.
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity.</typeparam>
            /// <param name="query">The query.</param>
            /// <param name="newItem">The item.</param>
            public virtual async Task Update(Expression<Func<TEntity, bool>> query, TEntity newItem)
            {
                string name = query.Parameters[0].Name;
    
                TEntity itemToUpdate = await this.Single(query);
                this.CopyValues(itemToUpdate, newItem);
    
                await client.Cypher
                   .Match("(" + name + ":" + newItem.Label + ")")
                   .Where(query)
                   .Set(name + " = {item}")
                   .WithParam("item", itemToUpdate)
                   .ExecuteWithoutResultsAsync();
            }
    
            public virtual async Task Patch(Expression<Func<TEntity, bool>> query, TEntity item)
            {
                string name = query.Parameters[0].Name;
    
                await client.Cypher
                   .Match("(" + name + ":" + item.Label + ")")
                   .Where(query)
                   .Set(name + " = {item}")
                   .WithParam("item", item)
                   .ExecuteWithoutResultsAsync();
            }
    
            public void CopyValues(TEntity target, TEntity source)
            {
                Type t = typeof(TEntity);
    
                var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);
    
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(source, null);
                    if (value != null)
                        prop.SetValue(target, value, null);
                }
            }
    
            /// <summary>
            /// Deletes an entity or entity set with the specified query.
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity.</typeparam>
            /// <param name="query">The query.</param>
            public virtual void Delete(Expression<Func<TEntity, bool>> query)
            {
                string name = query.Parameters[0].Name;
                TEntity entity = (TEntity)Activator.CreateInstance(query.Parameters[0].Type);
    
                client.Cypher
                    .Match("(" + name + ":" + entity.Label + ")")
                    .Where(query)
                    .Delete(name)
                    .ExecuteWithoutResults();
            }
    
            /// <summary>
            /// Relates one entity to another entity of the same or different type.
            /// </summary>
            /// <typeparam name="TEntity2"></typeparam>
            /// <typeparam name="TEntity"></typeparam>
            /// <param name="query1">The query1.</param>
            /// <param name="query2">The query2.</param>
            /// <param name="relationship">The relationship.</param>
            public virtual async Task Relate<TEntity2, TRelationship>(Expression<Func<TEntity, bool>> query1, Expression<Func<TEntity2, bool>> query2, TRelationship relationship)
                where TEntity2 : Neo4jEntity, new()
                where TRelationship : Neo4jRelationship, new()
            {
                string name1 = query1.Parameters[0].Name;
                TEntity entity1 = (TEntity)Activator.CreateInstance(query1.Parameters[0].Type);
                string name2 = query2.Parameters[0].Name;
                TEntity2 entity2 = (TEntity2)Activator.CreateInstance(query2.Parameters[0].Type);
    
                object properties = new object();
    
                await client.Cypher
                    .Match("(" + name1 + ":" + entity1.Label + ")", "(" + name2 + ":" + entity2.Label + ")")
                    .Where(query1)
                    .AndWhere(query2)
                    .CreateUnique(name1 + "-[:" + relationship.Name + " {rel}]->" + name2)
                    .WithParam("rel", relationship)
                    .ExecuteWithoutResultsAsync();
            }
    
            /// <summary>
            /// Gets the related.
            /// </summary>
            /// <typeparam name="TEntity2">The type of the entity2.</typeparam>
            /// <returns></returns>
            public virtual async Task<IEnumerable<TEntity2>> GetRelated<TEntity2, TRelationship>(Expression<Func<TEntity, bool>> query1, Expression<Func<TEntity2, bool>> query2, TRelationship relationship)
                where TEntity2 : Neo4jEntity, new()
                where TRelationship : Neo4jRelationship, new()
            {
                string name1 = query1.Parameters[0].Name;
                TEntity entity1 = (TEntity)Activator.CreateInstance(query1.Parameters[0].Type);
                string name2 = query2.Parameters[0].Name;
                TEntity2 entity2 = (TEntity2)Activator.CreateInstance(query2.Parameters[0].Type);
    
                Expression<Func<TEntity2, bool>> newQuery = PredicateRewriter.Rewrite(query2, "e");
    
                return await client.Cypher
                    .Match("(" + name1 + ":" + entity1.Label + ")-[:" + relationship.Name + "]->(" + name2 + ":" + entity2.Label + ")")
                    .Where(query1)
                    .AndWhere(query2)
                    .Return(e => e.As<TEntity2>())
                    .ResultsAsync;
            }
    
    
            /// <summary>
            /// Deletes the relationship.
            /// </summary>
            /// <typeparam name="TEntity2">The type of the entity2.</typeparam>
            /// <param name="query1">The query1.</param>
            /// <param name="query2">The query2.</param>
            /// <param name="relationship">The relationship.</param>
            /// <returns></returns>
            public virtual async Task DeleteRelationship<TEntity2, TRelationship>(Expression<Func<TEntity, bool>> query1, Expression<Func<TEntity2, bool>> query2, TRelationship relationship)
                where TEntity2 : Neo4jEntity, new()
                where TRelationship : Neo4jRelationship, new()
            {
                string name1 = query1.Parameters[0].Name;
                TEntity entity1 = (TEntity)Activator.CreateInstance(query1.Parameters[0].Type);
                string name2 = query2.Parameters[0].Name;
                TEntity2 entity2 = (TEntity2)Activator.CreateInstance(query2.Parameters[0].Type);
    
                await client.Cypher
                    .Match("(" + name1 + ":" + entity1.Label + ")-[r:" + relationship.Name + "]->(" + name2 + ":" + entity2.Label + ")")
                    .Where(query1)
                    .AndWhere(query2)
                    .Delete("r")
                    .ExecuteWithoutResultsAsync();
            }
        }    
    }
