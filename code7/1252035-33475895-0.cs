    using System;
    namespace InterfaceDesign
    {
        // the interface we're really interested in
        public interface IDataAccess
        {
            string GetData();
            void SetData(string data);
        }
        // a requirement for SQLDataAccess
        public interface ISession
        {
            void OpenSession();
            void CloseSession();
        }
        /// <summary>
        /// This "interface for the consumer" is intended only for classes that have no special needs before/after accessing data
        /// </summary>
        public class PlainDataAccess
        {
            internal PlainDataAccess(IDataAccess dataAccess)
            {
                this.DataAccess = dataAccess;
            }
            public IDataAccess DataAccess { get; private set; }
        }
        /// <summary>
        /// This "interface for the consumer" is intended for classes that have only the special needs to open/close sessions and be disposed.
        /// </summary>
        public class SessionedDataAccess
        {
            public IDataAccess DataAccess { get; private set; }
            public ISession Session { get; private set; }
            public IDisposable Disposable { get; private set; }
            /// <summary>
            /// Simplifies creation by not having to pass in the same variable 3 times
            /// </summary>
            internal static SessionedDataAccess Create<T>(T sessionedDataAccess) where T :IDataAccess, ISession, IDisposable
            {
                return new SessionedDataAccess(dataAccess: sessionedDataAccess , session: sessionedDataAccess , disposable: sessionedDataAccess);
            }
            private SessionedDataAccess(IDataAccess dataAccess, ISession session, IDisposable disposable)
            {
                this.DataAccess = dataAccess;
                this.Session = session;
                this.Disposable = disposable;
            }
            public  static SessionedDataAccess Create(PlainDataAccess dataAccess)
            {
                return new SessionedDataAccess(dataAccess: dataAccess.DataAccess, session: NoOpSession.Instance,
                    disposable: NoOpDisposable.Instance);
            }
            private class NoOpSession : ISession
            {
                public static readonly ISession Instance = new NoOpSession();
                public void OpenSession()
                {
                    Console.WriteLine("no op session opened");
                }
                public void CloseSession()
                {
                    Console.WriteLine("no op session closed");
                }
            }
            private class NoOpDisposable : IDisposable
            {
                public static readonly IDisposable Instance = new NoOpDisposable();
                public void Dispose()
                {
                    Console.WriteLine("no op disposed");
                }
            }
        }
        // further "consumer interfaces" can be added. Extension methods provide easy promotions to more "demanding" interfaces by using no-op implementations.
        /// <summary>
        /// A sample class that has no special need for sessions etc.
        /// </summary>
        public class FileDataAccess : IDataAccess
        {
            private FileDataAccess()
            {
            }
            public static PlainDataAccess Create()
            {
                return new PlainDataAccess(dataAccess: new FileDataAccess());
            }
            public string GetData()
            {
                return "from file";
            }
            public void SetData(string data)
            {
                Console.WriteLine("written to file");
            }
        }
        /// <summary>
        /// A more complex data access requiring sessions
        /// </summary>
        public class SQLDataAccess : IDataAccess, ISession, IDisposable
        {
            private SQLDataAccess()
            {
            }
            public static SessionedDataAccess Create()
            {
                return SessionedDataAccess.Create(new SQLDataAccess());
            }
            public string GetData()
            {
                return "from sql";
            }
            public void SetData(string data)
            {
                Console.WriteLine("written to SQL");
            }
            public void OpenSession()
            {
                Console.WriteLine("session opened");
            }
            public void CloseSession()
            {
                Console.WriteLine("Session closed");
            }
            public void Dispose()
            {
                Console.WriteLine("disposed");
            }
        }
   
        public static class Extensions
        {
            /// <summary>
            /// allows to use a plain data access as a sessioned data access by providing no-op  ISession and IDisposable implementations
            /// </summary>
            public static SessionedDataAccess Promote(this PlainDataAccess self)
            {
                return SessionedDataAccess.Create(dataAccess: self);
            }
        }
        public class ConsumerExamples
        {
            public void Provider()
            {
                var fileAccess = FileDataAccess.Create();
                var sqlDataAccess = SQLDataAccess.Create();
                Consume1(sqlDataAccess);
            
                //Consume2(sqlDataAccess);  // this won't compile
                Consume1(fileAccess.Promote());
                Consume2(fileAccess);
            }
            /// <summary>
            /// This consumer is prepared to handle sessions.
            /// Can handle our sql data access and (after promotion) the basic file data access
            /// </summary>
            public void Consume1(SessionedDataAccess sessionedDataAccess)
            {
                sessionedDataAccess.Session.OpenSession();
                Console.WriteLine(
                    sessionedDataAccess.DataAccess.GetData()
                    );
                sessionedDataAccess.DataAccess.SetData("data");
                sessionedDataAccess.Session.CloseSession();
                sessionedDataAccess.Disposable.Dispose();
            }
            // can consume only file access
            /// <summary>
            /// This consumer is NOT prepared to handle sessions.
            /// It can only handle the file access.
            /// There is no way (without cheating) to pass in a SQL data access here
            /// </summary>
            public void Consume2(PlainDataAccess dataAccess)
            {
                Console.WriteLine(
                    dataAccess.DataAccess.GetData()
                    );
                dataAccess.DataAccess.SetData("data");
            }
        }
    }
