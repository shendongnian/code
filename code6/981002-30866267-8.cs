    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Data.Models;
    
    namespace Data.Repository
    {
        public interface IRepository<TEntity> where TEntity : IEntity, new()
        {
            /// <summary>
            /// Gets all.
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity.</typeparam>
            /// <returns></returns>
            Task<IEnumerable<TEntity>> All();
    
            /// <summary>
            /// Finds a collection of entities with the specified query.
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity.</typeparam>
            /// <param name="query">The query.</param>
            /// <returns></returns>
            Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> query);
            /// <summary>
            /// Gets the by.
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity.</typeparam>
            /// <param name="query">The query.</param>
            /// <returns></returns>
            Task<TEntity> Single(Expression<Func<TEntity, bool>> query);
            /// <summary>
            /// Adds the specified item.
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity.</typeparam>
            /// <param name="item">The item.</param>
            void Add(TEntity item);
            /// <summary>
            /// Updates the entities with specified query.
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity.</typeparam>
            /// <param name="query">The query.</param>
            /// <param name="item">The item.</param>
            Task Update(Expression<Func<TEntity, bool>> query, TEntity item);
            /// <summary>
            /// Deletes the entities with the specified query.
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity.</typeparam>
            /// <param name="query">The query.</param>
            void Delete(Expression<Func<TEntity, bool>> query);
        }
    }
