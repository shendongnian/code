    public interface AbstractDataModel { }
    public class UDataModel : AbstractDataModel { }
    public class FDataModel : AbstractDataModel { }
    public class UCommandProcessor : AbstractCommandProcessor<UDataModel> { }
    public class FCommandProcessor : AbstractCommandProcessor<UDataModel> { }
    public interface AbstractCommandProcessor<out TDataModel> : SomeInterface<TDataModel>
     where TDataModel : AbstractDataModel
    { }
    public interface SomeInterface<out TDataModel> where TDataModel : AbstractDataModel { }
    ...
    var processor = 
      (AbstractCommandProcessor<AbstractDataModel>)Activator.CreateInstance(processorType);
