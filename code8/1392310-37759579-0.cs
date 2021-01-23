    using System;
    using Template.DomainServices;
    namespace Template.Web {
        public class MyClass {
            ILogger logger = new DomainServices.DefaultLogger();
            public void Log(string msg) {
                logger.Log(msg);
            }
        }
    }
