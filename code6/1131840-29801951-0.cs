        public interface IAgent
        {
            void Action( );
            int Calculate( );
        }
        public interface IAgent< T > : IAgent
        {
          void Set( T value );
        }
        public class MyClass
        {
            public void DoSomething< T >( T agent ) where T : IAgent
            {
                //...
            }
    
            public void TypeNeeded< T, V >( T agent ) where T : IAgent<V>
            {	
            }
        }
