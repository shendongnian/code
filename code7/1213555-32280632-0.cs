    public class Structure< T, S> : IStructure<S>
    where S : StructureStats, new()
    where T : StructureModel<S>, new()
    {
        protected T _model;
    
        public S Stats { get { return _model.Stats; } set { _model.Stats = value; } }
    
    }
    
    public interface IStructure<S> where S : StructureStats
    {
        S Stats { get; set; }
    }
