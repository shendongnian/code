    public abstract class BaseRepository
    {
      protected abstract void DeleteEntityWithProcedure(int key, ObjectParameter error);
      public void DeleteEntity(int Key)
      {
        try
        {
            ObjectParameter error = new ObjectParameter("Error", typeof(string));
            DeleteEntityWithProcedure(key, error);
            if (error.Value.ToString() != "")
            {
                Errores myerror = new Errores();
                myerror.ID = 100;
                myerror.Descripcion = error.Value.ToString();
                MyErrors.Add(myerror);
            }
        }
        catch (DbUpdateConcurrencyException ex)
        {
            // Update the values of the entity that failed to save from the store 
            ex.Entries.Single().Reload();
            // status = ex.Message; 
            Errores myerror = new Errores();
            myerror.ID = 1000;
            myerror.Descripcion = ex.Message.ToString();
            MyErrors.Add(myerror);
        }
        catch (DbUpdateException ex)
        {
            string status = (ex.InnerException.InnerException != null) ? ex.InnerException.InnerException.Message : "";
            Errores myerror = new Errores();
            myerror.ID = 1000;
            myerror.Descripcion = status;
            MyErrors.Add(myerror);
        }
        catch (Exception ex)
        {
            //paso los errores
            Errores myerror = new Errores();
            myerror.ID = 1000;
            myerror.Descripcion = ex.Message.ToString();
            MyErrors.Add(myerror);
        }
    }
