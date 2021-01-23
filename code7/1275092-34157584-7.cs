        // display classes for static lambdas do not have any data and can be serialized.
        internal override bool IsSerializable
        {
            get { return (object)_singletonCache != null; }
        }
