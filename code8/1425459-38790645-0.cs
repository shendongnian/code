    class BaseModel {
        public virtual MappedModelBase Map() {
            var result = new MappedBaseModel();
            // ...
            return result;
        }
    }
    class ChildModel : BaseModel {
        public override MappedModelBase Map() {
            var result = new MappedChildModel();
            // ...
            return result;
        }
    }
