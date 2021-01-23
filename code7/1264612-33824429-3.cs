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
    public class EstadoState : IEstadoState
    {
        public int Id {get; set;}
    }
    public class EstadoBaseMO : IEstadoMO
    {
        public int Id { get; set; }
    }
    public class EstadoBaseBO : IEstadoBO
    {
        public IEstadoState Insert(IEstadoMO estado) { return new EstadoState(); }
    }
    public class EstadoSAMO : EstadoBaseMO { }
    public class EstadoGesDocMO : EstadoBaseMO { }
    public class EstadoGesDocBO : EstadoBaseBO { }
    public class EstadoSABO : EstadoBaseBO { }
    public class SolicitudGesDocPresenter : SolicitudBasePresenter<EstadoGesDocMO, EstadoGesDocBO> { }
    public class SolicitudSAPresenter : SolicitudBasePresenter<EstadoSAMO, EstadoSABO> { }
