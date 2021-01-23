    public class ModelSemiWrapperBase<TModel> 
    {
       public ModelSemiWrapperBase(TModel model)
       {
           this.Model = model;
       }
       public TModel Model
       {
           get;
           private set;
       }
    }
    
    public class GoodSemiWrapper : ModelSemiWrapperBase<Good>
    {
        public String HasTax
        {
            get
            {
                return (this.Model.HasTax == 0) ? ("Yes") : ("No");
            }
            set {...}
        }
    }
