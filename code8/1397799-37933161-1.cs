    public static class MyStaticClass
    {
    // Define other methods and classes here
    	public static void AddType<T>(
    		Func<XmlReader, T> ReaderFunc,
    		Action<T, XmlWriter> WriterFunc ){
    		/*Magic stuff happens here*/
    	}
    }
    
    
    public abstract class XmlModel<T> where T : XmlModel<T>, new( )
    {
        public XmlModel( ){
            //Type Inference kicks in with other tests, but not this one T_T
            MyStaticClass.AddType<T>( ReadModel, WriteModel );
        }
    
        private T ReadModel( XmlReader reader )  
    	{
            T model = new T( );
            model.ReadXml( reader );
            return model;
        }
    
        private void WriteModel( T model, XmlWriter writer ) 
    	{
            model.WriteXml( writer );
        }
    
        public abstract void ReadXml( XmlReader reader );
        public abstract void WriteXml( XmlWriter writer );
    }
