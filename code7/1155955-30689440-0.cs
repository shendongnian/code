    class TempTest
        {
            public static void Run()
            {
                IData data = new InitData() { IntegerData = 1, StringData = "some" };
    
                IBaseControl c1 = new ControlA();
                IBaseControl c2 = new ControlB();
    
                c1.Init( data );
                c2.Init( data );
            }
        }
    
    
        // Interfaces
    
        public interface IData
        {
            int IntegerData { get; set; }
            string StringData { get; set; }
        }
    
        public interface IBaseControl
        {
            void Init( IData data );
        }
    
        public interface IControlA
        {
            void Init( int IntegerData );
        }
    
        public interface IControlB
        {
            void Init( int IntegerData, string StringData );
        }
    
    
        // Base classes
    
        public abstract class Base : IBaseControl
        {
            #region IBaseControl Members
    
            public abstract void Init( IData data );
    
            #endregion
        }
    
    
        // Concrete classes
    
        public class InitData : IData
        {
            public int IntegerData { get; set; }
            public string StringData { get; set; }
        }
    
        public class ControlA : Base, IControlA
        {
            public override void Init( IData data )
            {
                Init( data.IntegerData );
            }
    
            #region IControlA Members
    
            public void Init( int IntegerData )
            {
                Console.WriteLine( "ControlA initialized with IntegerData={0}", IntegerData );
            }
    
            #endregion
        }
    
        public class ControlB : Base, IControlB
        {
            public override void Init( IData data )
            {
                Init( data.IntegerData, data.StringData );
            }
    
            #region IControlB Members
    
            public void Init( int IntegerData, string StringData )
            {
                Console.WriteLine( "ControlB initialized with IntegerData={0} and StringData={1}", IntegerData, StringData );
            }
    
            #endregion
        }
