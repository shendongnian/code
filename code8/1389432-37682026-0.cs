    // Use workaround on BaseTask
    public abstract class BaseTask<TProc, TProcParam, TParam>
       where TProc : BaseProcess<TProcParam>
       where TProcParam : BaseParam
       where TParam : TProcParam
    {
    }
    // Generic shortcut overload
    public abstract class BaseTask<TProc, TParam> : BaseTask<TProc, TParam, TParam>
       where TProc : BaseProcess<TProcParam>
       where TParam : TProcParam
    {
    }
