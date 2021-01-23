        public class Car
        {
            void method1()
            {
                try
                {
                    //...
                }
                catch (Exception exception)
                {
                    ExceptionManager.Handle(exception);
                }
            }
        }
        public static class ExceptionManager
        {
            public static void Handle(Exception exception)
            {
                try
                {
                    //Handle Exception
                }
                catch { }
            }
        }
