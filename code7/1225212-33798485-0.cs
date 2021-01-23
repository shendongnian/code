    public class AsyncValidationPipeline<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse>
        where TRequest : IAsyncRequest<TResponse>
    {
        private IAsyncRequestHandler<TRequest, TResponse> _inner;
        private IValidator<TRequest>[] _validators;
    
        public AsyncValidationPipeline(IAsyncRequestHandler<TRequest, TResponse> inner,
            IValidator<TRequest>[] validators)
        {
            _inner = inner;
            _validators = validators;
        }
        public Task<TResponse> Handle(TRequest message)
        {
            List<string> errors = new List<string>();
            if (_validators != null && _validators.Any())
            {
                errors = _validators.Where(v => v.Fails(message))
                    .Select(v => v.ErrorMessage);
            }
    
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
            return _inner.Handle(message);
        }
    }
