    abstract class BaseControl
    {
        protected void SubscribeToContract<Type>(IContract<Type> contract) 
            where Type : EventArgs
        {
            contract.ContractChanged += 
                delegate(object sender, Type e)
                {
                    // Calls this method to perform other actions:
                    OnContractChanged(e);
                };
        }
        // Called when IContract<>.ContractChanged is raised:
        protected virtual void OnContractChanged(EventArgs e);
    }
    class SpecialControl : BaseControl, IContract<SpecialEventArgs>
    {
        ...
        protected override OnContractChanged(EventArgs e)
        {
            base.OnContractChanged();
            PerformAction(e);
        }
        ...
        void PerformAction(EventArgs e)
        {
            // We can also now find out if "e" is SpecialEventArgs
            if (e is SpecialEventArgs)
            {
                ...
            }
            ...
        }
       ...      
    }
