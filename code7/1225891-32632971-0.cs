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
    abstract class Procedure1 : ProcedureBase<TypeToReturn>
    {
        protected override TypeToReturnProtectedWork ProtectedWork()
        {
            //Do something
        }
    }
    abstract class Procedure2 : ProcedureBase<AnotherTypeToReturn>
    {
        protected override AnotherTypeToReturn ProtectedWork()
        {
            //Do something
        }
    }
