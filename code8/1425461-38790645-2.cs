    public class Mapper
    {
        public MappedBaseModel MapModel(BaseModel source);
        public MappedBaseModel MapModel(ChildModel source);
    }
    class BaseModel 
    {
        public virtual MappedBaseModel MapWith(Mapper mapper)
        {
            return mapper.MapModel(this);
        }
    }
    class ChildModel : BaseModel 
    {
        public override MappedBaseModel MapWith(Mapper mapper)
        {
            return mapper.MapModel(this);
        }
    }
    var mapper = new Mapper();
    foreach(var model in overallModel.Models)
        list.Add(model.MapWith(mapper));
