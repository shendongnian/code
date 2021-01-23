    public class SolicitudBasePresenter<T1, T2> where T1 : IEstadoMO where T2 : IEstadoBO, new()
    {
        public bool SaveNewDetailStates(List<T1> estados) 
        {
            bool result = true;
            if (estados.Any())
            {
                try
                {
                    foreach (var estado in estados)
                    {
                        var estadoBO = new T2();
                        var savedState = estadoBO.Insert(estado);
                        result &= ((savedState != null) && (savedState.Id != estado.Id));
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }
            return result;
        }
    }
