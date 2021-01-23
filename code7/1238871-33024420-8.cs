    public class ValueCastInvoker : IOperationInvoker
    {
        readonly IOperationInvoker _invoker;
        public ValueCastInvoker(IOperationInvoker invoker)
        {
            _invoker = invoker;
        }
        public ValueCastInvoker(IOperationInvoker invoker, Type type, Object value)
        {
            _invoker = invoker;
        }
        public object[] AllocateInputs()
        {
            return _invoker.AllocateInputs().ToArray();
        }
        private object[] CastCorrections(object[] inputs)
        {
            Guid obj;
            var value = inputs[0] as string;
            if (Guid.TryParse(value, out obj))
            {
                return new[] { (object)obj }.Concat(inputs.Skip(1)).ToArray();
            }
            return inputs.ToArray();
        }
        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            return _invoker.Invoke(instance, CastCorrections(inputs), out outputs);
        }
        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            return _invoker.InvokeBegin(instance, inputs, callback, state);
        }
        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            return _invoker.InvokeEnd(instance, out outputs, result);
        }
        public bool IsSynchronous
        {
            get { return _invoker.IsSynchronous; }
        }
    }
