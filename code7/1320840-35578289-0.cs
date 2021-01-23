    namespace ClassLibrary1
    {
        using System;
        using System.Collections.Generic;
        using System.Linq.Expressions;
        using MongoDB.Driver;
        /// <summary>
        /// The class 1.
        /// </summary>
        public class Class1
        {
            /// <summary>
            /// The get data.
            /// </summary>
            public async void GetData()
            {
                var context = new Context();
                var searchString = "1234";
                Expression<Func<SomeThing, bool>> filter = x =>
                x.Contact.Exists(s => s.FirstName == searchString
                && x.Contact.Exists(l=>l.LastName == searchString));
                var result = await context.SomeThingCollection.FindAsync(filter);
            }
        }
        /// <summary>
        /// The context.
        /// </summary>
        public class Context
        {
            public const string CONNECTION_STRING_NAME = " ";
            public const string DATABASE_NAME = " ";
            public const string COLLECTION_NAME = "name";
            private static readonly IMongoClient _client;
            private static readonly IMongoDatabase _database;
            static Context()
            {
                var connectionString = "connectionString";
                _client = new MongoClient(connectionString);
                _database = _client.GetDatabase(DATABASE_NAME);
            }
            public IMongoCollection<SomeThing> SomeThingCollection
            {
                get
                {
                    return _database.GetCollection<SomeThing>(COLLECTION_NAME);
                }
            }
        }
        public class SomeThing
        {
            public List<Contact> Contact { get; set; }
        }
        public class Contact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
