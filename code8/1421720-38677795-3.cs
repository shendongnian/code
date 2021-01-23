    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    namespace Sandbox
    {
        public class NewsArticle
        {
            public string Text { get; set; }
        }
        public class NewsArticleRepository
        {
            /// <summary>
            /// This demonstartes how to perform the logic with a simple LINQ query.
            /// Untetested with Linq to EF.
            /// </summary>
            public IEnumerable<NewsArticle> GetArticlesWithKeywordsUsingLinq(IQueryable<NewsArticle> articles, IEnumerable<string> keywords)
            {
                var keywordGroups = keywords.Select(k => k.Split(' ')).ToArray();
                var filteredArticles = articles.Where(article => keywordGroups.
                    Any(keywordGroup => keywordGroup.
                        All(keyword => article.Text.Contains(keyword))));
                var result = filteredArticles.AsEnumerable();
                return result;
            }
            /// <summary>
            /// This demonstartes how to perform the logic with an expression tree;
            /// This is probably more efficient when converted to SQL.
            /// Untetested with Linq to EF.
            /// </summary>
            public IEnumerable<NewsArticle> GetArticlesWithKeywordsUsingExpressionTree(IQueryable<NewsArticle> articles, IEnumerable<string> keywords)
            {
                var keywordGroups = keywords.Select(k => k.Split(' ')).ToArray();
                var filteredArticles = articles.Where(GetWhereClauseForKeywordGroups(keywordGroups));
                var result = filteredArticles.AsEnumerable();
                return result;
            }
            /// <summary>
            /// This demonstartes how to perform the logic with an expression tree;
            /// This is probably even more efficient when converted to SQL because it uses a UNION instead of OR.
            /// Untetested with Linq to EF.
            /// </summary>
            public IEnumerable<NewsArticle> GetArticlesWithKeywordsUsingExpressionTreeWithUnion(IQueryable<NewsArticle> articles, IEnumerable<string> keywords)
            {
                var keywordGroups = keywords.Select(k => k.Split(' ')).ToArray();
                var filteredArticles = articles.Where(a => false);
                foreach (var keywordGroup in keywordGroups)
                {
                    var articlesWithAllKeywordsInGroup = articles.Where(GetWhereClauseForKeywordGroup(keywordGroup));
                    filteredArticles = filteredArticles.Union(articlesWithAllKeywordsInGroup);
                }
                var result = filteredArticles.AsEnumerable();
                return result;
            }
            private Expression<Func<NewsArticle, bool>> GetWhereClauseForKeywordGroup(string[] keywordGroup)
            {
                var containsMethod = GetContainsMethod();
                var article = Expression.Parameter(typeof(NewsArticle), "article");
                Expression containsAllKeywords = Expression.Constant(true);
                foreach (var keyword in keywordGroup)
                {
                    var containsKeyword = Expression.Call(
                        Expression.Property(article, "Text"),
                        containsMethod,
                        Expression.Constant(keyword));
                    containsAllKeywords = Expression.And(containsAllKeywords, containsKeyword);
                }
                var whereClause = Expression.Lambda<Func<NewsArticle, bool>>(containsAllKeywords, article);
                return whereClause;
            }
            private Expression<Func<NewsArticle, bool>> GetWhereClauseForKeywordGroups(string[][] keywordGroups)
            {
                var containsMethod = GetContainsMethod();
                var article = Expression.Parameter(typeof(NewsArticle), "article");
                Expression containsSomeKeywordGroup = Expression.Constant(false);
                foreach (var keywordGroup in keywordGroups)
                {
                    Expression containsAllKeywords = Expression.Constant(true);
                    foreach (var keyword in keywordGroup)
                    {
                        var containsKeyword = Expression.Call(
                            Expression.Property(article, "Text"),
                            containsMethod,
                            Expression.Constant(keyword));
                        containsAllKeywords = Expression.And(containsAllKeywords, containsKeyword);
                    }
                    containsSomeKeywordGroup = Expression.Or(containsSomeKeywordGroup, containsAllKeywords);
                }
                var whereClause = Expression.Lambda<Func<NewsArticle, bool>>(containsSomeKeywordGroup, article);
                return whereClause;
            }
            private static MethodInfo GetContainsMethod()
            {
                var stringMethods = typeof(string).
                    GetMethods(BindingFlags.Instance | BindingFlags.Public).ToArray();
                var containsMethods = stringMethods.Where(m => m.Name == "Contains");
                var containsMethod = containsMethods.Single();
                return containsMethod;
            }
        }
    
        public class Tests
        {
            private NewsArticle _requestedExample;
            private NewsArticle _missingWord;
            private NewsArticle _inOrder;
            private NewsArticle _outOfOrder;
            private IQueryable<NewsArticle> _articles;
            private List<string> _keywords;
            [SetUp]
            public void SetUp()
            {
                this._keywords = new List<string>
                {
                    "Lorem ipsum dolor",
                    "elementum lacinia",
                    "cursus nulla molestie"
                };
                this._requestedExample = new NewsArticle
                {
                    Text = "Requested Example: ipsum example Lorem text dolor"
                };
                this._missingWord = new NewsArticle
                {
                    Text = "Missing word: cursus nulla"
                };
                this._inOrder = new NewsArticle
                {
                    Text = "In Order: Lorem ipsum dolor"
                };
                this._outOfOrder = new NewsArticle
                {
                    Text = "Out of Order: Lorem dolor ipsum"
                };
                this._articles = new[]
                {
                    this._requestedExample,
                    this._missingWord,
                    this._inOrder,
                    this._outOfOrder,
                }.AsQueryable();
            }
            [Test]
            public void GetArticlesWithKeywordsUsingLinqShouldWork()
            {
                var result = new NewsArticleRepository().GetArticlesWithKeywordsUsingLinq(this._articles, this._keywords).ToArray();
                AssertResult(result);
            }
            [Test]
            public void GetArticlesWithKeywordsUsingExpressionTreeShouldWork()
            {
                var result = new NewsArticleRepository().GetArticlesWithKeywordsUsingExpressionTree(this._articles, this._keywords).ToArray();
                AssertResult(result);
            }
            [Test]
            public void GetArticlesWithKeywordsUsingExpressionTreeWithUnionShouldWork()
            {
                var result = new NewsArticleRepository().GetArticlesWithKeywordsUsingExpressionTreeWithUnion(this._articles, this._keywords).ToArray();
                AssertResult(result);
            }
            private void AssertResult(NewsArticle[] result)
            {
                Assert.That(result.Contains(this._requestedExample), Is.True);
                Assert.That(result.Contains(this._missingWord), Is.False);
                Assert.That(result.Contains(this._inOrder), Is.True);
                Assert.That(result.Contains(this._outOfOrder), Is.True);
            }
        }
    }
