    public class A<T>
    {
        public void MethodA()
        {
            List<T> recordToValidate = GetBulkRecordsToBeValidated(profileId);
            ....
        }
    
        internal virtual List<T> GetBulkRecordsToBeValidated(int profileId) // you might want to make this an abstract method instead of virtual
        {
            ....
        }       
    }
    public class C : A<ModelCRecords>
    {
        internal override List<ModelCRecords> GetBulkRecordsToBeValidated(int profileId)
        {
            return makes call to database which returns a List<ModelCRecords>
        }
    }
