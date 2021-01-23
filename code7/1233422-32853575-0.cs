    using System;
    using System.Diagnostics.Contracts;
    public sealed class Weird
    {        
        public Weird(object science)
        {
            if (science == null)
            {
                throw new ArgumentNullException();
            }
            Contract.EndContractBlock();
            this.science = science;
        }
        private readonly object science;
        private object Science
        {
            get
            {
                return this.science;
            }
        }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(null != this.Science);
        }
    }
