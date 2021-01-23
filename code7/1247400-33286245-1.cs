    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using NHibernate.Linq;
    using Remotion.Linq;
    namespace LittleFish.Persistence.Extensions
    {
        /// <summary>
        /// Provides extension method wrappers for NHibernate methods 
        /// to allow consuming source code to avoid "using" NHibernate.
        /// </summary>
        public static class NHibernateExtensions
        {
            /// <summary>
            /// Eager-loads a projection of the specified queryable, 
            /// referencing a mapped child object.
            /// </summary>
            public static IFetchRequest<T, TRel> EagerlyFetch<T, TRel>(
                this IQueryable<T> queryable,
                Expression<Func<T, TRel>> expression)
            {
                if (queryable is QueryableBase<T>)
                    return FetchHelper.Create(queryable.Fetch(expression));
                else
                    return FetchHelper.CreateNonNH<T, TRel>(queryable);
            } 
            /// <summary>
            /// Eager-loads a second-level projection of the specified queryable, 
            /// referencing a mapped child of the first eager-loaded child.
            /// </summary>
            public static IFetchRequest<T, TRel2> ThenEagerlyFetch<T, TRel, TRel2>(
                this IFetchRequest<T, TRel> queryable,
                Expression<Func<TRel, TRel2>> expression)
            {
                if (queryable is QueryableFetchHelper<T, TRel>)
                    return FetchHelper.CreateNonNH<T, TRel2>(queryable);
                else
                    return FetchHelper.Create(queryable.ThenFetch(expression));
            } 
            /// <summary>
            /// Eager-loads a projection of the specified queryable, 
            /// referencing a mapped child object.
            /// </summary>
            public static IFetchRequest<T, TRel> EagerlyFetchMany<T, TRel>(
                this IQueryable<T> queryable,
                Expression<Func<T, IEnumerable<TRel>>> expression)
            {
                if(queryable is QueryableBase<T>)
                    return FetchHelper.Create(queryable.FetchMany(expression));
                else
                    return FetchHelper.CreateNonNH<T, TRel>(queryable);
            } 
            /// <summary>
            /// Eager-loads a second-level projection of the specified queryable, 
            /// referencing a mapped child of the first eager-loaded child.
            /// </summary>
            public static IFetchRequest<T, TRel2> ThenEagerlyFetchMany
                <T, TRel, TRel2>(
                this IFetchRequest<T, TRel> queryable,
                Expression<Func<TRel, IEnumerable<TRel2>>> expression)
            {
                if (queryable is QueryableFetchHelper<T, TRel>)
                    return FetchHelper.CreateNonNH<T, TRel2>(queryable);
                else
                    return FetchHelper.Create(queryable.ThenFetchMany(expression));
            }
        } 
        /// <summary>
        /// Provides a wrapper for NHibernate's FetchRequest interface, 
        /// so libraries that run eager-loaded queries don't have to reference 
        /// NHibernate assemblies.
        /// </summary>
        public interface IFetchRequest<TQuery, TFetch> :
            INhFetchRequest<TQuery, TFetch>
        {
        } 
        internal class NhFetchHelper<TQuery, TFetch> : IFetchRequest<TQuery, TFetch>
        {
            private readonly INhFetchRequest<TQuery, TFetch> realFetchRequest;
            //this is the real deal for NHibernate queries
            internal NhFetchHelper(INhFetchRequest<TQuery, TFetch> realFetchRequest)
            {
                this.realFetchRequest = realFetchRequest;
            } 
            public IEnumerator<TQuery> GetEnumerator()
            {
                return (realFetchRequest).GetEnumerator();
            } 
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (realFetchRequest).GetEnumerator();
            } 
            public Expression Expression
            {
                get { return (realFetchRequest).Expression; }
            } 
            
            public Type ElementType
            {
                get { return (realFetchRequest).ElementType; }
            } 
            public IQueryProvider Provider
            {
                get { return (realFetchRequest).Provider; }
            }
        } 
        internal class QueryableFetchHelper<TQuery, TFetch> :
            IFetchRequest<TQuery, TFetch>
        {
            private readonly IQueryable<TQuery> queryable;
            //for use against non-NH datastores
            internal QueryableFetchHelper(IQueryable<TQuery> queryable)
            {
                this.queryable = queryable;
            } 
            
            public IEnumerator<TQuery> GetEnumerator()
            {
                return (queryable).GetEnumerator();
            } 
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (queryable).GetEnumerator();
            } 
            
            public Expression Expression
            {
                get { return (queryable).Expression; }
            } 
            public Type ElementType
            {
                get { return (queryable).ElementType; }
            } 
            public IQueryProvider Provider
            {
                get { return (queryable).Provider; }
            }
        } 
        /// <summary>
        /// The static "front door" to FetchHelper, with generic factories allowing 
        /// generic type inference.
        /// </summary>
        internal static class FetchHelper
        {
            public static NhFetchHelper<TQuery, TFetch> Create<TQuery, TFetch>(
                INhFetchRequest<TQuery, TFetch> nhFetch)
            {
                return new NhFetchHelper<TQuery, TFetch>(nhFetch);
            } 
            public static NhFetchHelper<TQuery, TFetch> Create<TQuery, TFetch>(
                IFetchRequest<TQuery, TFetch> nhFetch)
            {
                return new NhFetchHelper<TQuery, TFetch>(nhFetch);
            } 
            public static IFetchRequest<TQuery, TRel> CreateNonNH<TQuery, TRel>(
                IQueryable<TQuery> queryable)
            {
                return new QueryableFetchHelper<TQuery, TRel>(queryable);
            }
        }
    }
