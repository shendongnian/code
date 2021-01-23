    public abstract  class Equipment
    {
        public abstract Detail GetDetail();
    }
    
    public sealed class EquimpmentAA : Equipment
    {
        private readonly IGetDetail _getDetail;
        public EquimpmentAA( IGetDetail getDetail)
        {
            _getDetail = getDetail;
        }
    
    
        public override Detail GetDetail()
        {
            return _getDetail.Get();
        }
    }
    
    public sealed class Detail 
    {
       //Details
    }
    
    //Different implementations on how each class gets its detail
    public interface IGetDetail
    {
        Detail Get();
    }
