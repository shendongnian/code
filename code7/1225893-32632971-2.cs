    abstract class ProcedureBase<T>
    {
        public T Work()
        {
			using(sftpClient)
			{
				sftpClient.Connect();
				try{
					ProtectedWork();
				}
				catch(Exception ex)
				{
				}
				sftpClient.Disconnect();
			}
        }
        protected abstract T ProtectedWork();
    }
    class Procedure1 : ProcedureBase<TypeToReturn>
    {
        protected override TypeToReturn ProtectedWork()
        {
            //Do something
        }
    }
    class Procedure2 : ProcedureBase<AnotherTypeToReturn>
    {
        protected override AnotherTypeToReturn ProtectedWork()
        {
            //Do something
        }
    }
