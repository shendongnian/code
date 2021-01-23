    public abstract class DBAccess
    {
        protected MetaData metaData;
    }
    
    public class OldDBAccess : DBAccess
    {
        public OldDBAccess()
        {
            metaData = new OldDBMetaData();
        }
    
        public void TestSetName(string name)
        {
            // You want to do this one, but you cannot because the abstract class MetaData doest not exist OldName property
            // metaData.OldName = name;
            // I can simple resolve this problem by cast this to the OldDBMetaData
               ((OldDBMetaData)metaData.OldName) = name; 
        }
    }
