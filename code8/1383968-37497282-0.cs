    public class BaseFoo<TOutput, TInput>
        where TOutput : BaseOutput
    {
        public TOutput Something { get; set; }
    }
    
    public class Bar : BaseFoo<ExtendOutput, ExtendInput>
    {
    }
    public class BaseInput { }
    public class BaseOutput { }
    public class ExtendOutput : BaseOutput { }
    public class SomethingElse : BaseOutput { }
