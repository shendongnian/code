    class ControllerClass
    {
        private IClientGroup _clientgroup;
        public ControllerClass(IClientGroup clientgroup)
        {
           if(clientgroup == null)
           {
               //Don't allow null values
               throw new ArgumentNullException("clientgroup");
           }
           this._clientgroup = clientgroup
        }
        void SomeMethod()
        {
            //Use this._clientgroup here
        }
    }
