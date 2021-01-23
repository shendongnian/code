    public class BusinessService()
    {
        public int Insert(ModelName model)
        {
            ctx.TheTargetedEntity.Add(model);
            ctx.SaveChanges();
            return model.id;
        }
    }
    public class PresentationService()
    {
        public int Insert(MyActionViewModel theVm)
        {
            ModelName mn = new ModelName();
            mn.AddressLineOne = theVm.AddressLineOne;
            mn.AddressLineTwo = theVm.AddressLineTwo;
            return businessService.Insert(mn);
        }
    }
