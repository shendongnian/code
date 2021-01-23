    class OperationFactory<T> where T : Operation
        {
            private Func<T> ObjectCreation;
    
            private T ValidObject;
    
    
            public OperationFactory(Func<T> ObjectCreation)
            {
                IsValid = false;
                this.ObjectCreation = ObjectCreation;
            }
    
    
            /// <summary>
            /// While is True then the same operation is returned.
            /// Set it to False to invalidate current operation so the next call to get operation will return new operation.
            /// </summary>
            public bool IsValid { get; set; }
    
    
    
            public T GetOperation()
            {
                if (IsValid == false)
                {
                    ValidObject = ObjectCreation();
                    IsValid = true;
                }
    
                return ValidObject;
            }
    
        }
    class StocktakingOperationFactory : OperationFactory<StocktakingOperation>
        {
            public StocktakingOperationFactory(Func<StocktakingOperation> ObjectCreation)
                : base(ObjectCreation)
            {
    
            }
        }
