    public class CustomerRepository:BaseRepository
    {
       protected override DeleteEntityWithProcedure(int key, ObjectParameter error)
        {
          //execute procedure you needed
          //context.proc_BorrarChofer(Key, error); 
        }
    }
