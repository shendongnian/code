    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    namespace ConsoleApplication93
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<TopicFromDatabase> topics = new List<TopicFromDatabase>(){
                    new TopicFromDatabase() {
                        TopicID = 123,
                        TopicName = "abc",
                        LanguageID = 456,
                        LanguageName = "def",
                        ApplicationID = 789,
                        ApplicationName = "ghi",
                        ArticleID = 234,
                        Headline = "jkl",
                        IsSticky = true
                    }
                };
                var results = topics.Select(x => new
                {
                    topic = new Topic()
                    {
                        TopicId = x.TopicID,
                        TopicName = x.TopicName,
                        LanguageId = x.LanguageID,
                        ApplicationId = x.ApplicationID,
                        Articles = new List<IArticle>() {
                            new Article() {
                                ArticleId = x.ArticleID,
                                Headline = x.Headline,
                                IsSticky = x.IsSticky 
                            }
                        }
                    }
                });
            }
        }
        public partial class TopicFromDatabase
        {
            public int TopicID { get; set; }
            public string TopicName { get; set; }
            public int LanguageID { get; set; }
            public string LanguageName { get; set; }
            public int ApplicationID { get; set; }
            public string ApplicationName { get; set; }
            public int ArticleID { get; set; }
            public string Headline { get; set; }
            public bool IsSticky { get; set; }
        }
        public class ITopic
        {
        }
        public class Topic : ITopic
        {
            public int TopicId { get; set; }
            public string TopicName { get; set; }
            public int LanguageId { get; set; }
            public int ApplicationId { get; set; }
            public IEnumerable<IArticle> Articles { get; set; }
        }
        public class IArticle
        {
        }
        public class Article : IArticle
        {
            public int ArticleId { get; set; }
            public string Headline { get; set; }
            public string Content { get; set; }
            public bool IsSticky { get; set; }
        }
    }
