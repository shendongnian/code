    public interface IEstadoState 
    {
        int Id { get; set; }
    }
    public interface IEstadoMO
    {
        int Id { get; set; }
    }
    public interface IEstadoBO
    {
        IEstadoState Insert(IEstadoMO estadoMO);
    }
    public class SolicitudBasePresenter
    {
        public virtual bool SaveNewDetailStates(List<IEstadoMO> estados, IEstadoBO estadoBO) 
        {
            bool result = true;
            if (estados.Any())
            {
                try
                {
                    foreach (var estado in estados)
                    {
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
    public class SolicitudGesDocPresenter : SolicitudBasePresenter { }
    public class SolicitudSAPresenter : SolicitudBasePresenter { }
