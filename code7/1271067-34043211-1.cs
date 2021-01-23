    class MyClass {
        MITIntegration integration;
        MyIntegrationDelegate integration_delegate;
        void Initialize ()
        {
            integration = new MITIntegration ();
            integration.Delegate = integration_delegate; 
        }
    }
    class MyIntegrationDelegate : MITIntegrationDelegate {
        public override void DidFinishSendMail ()
        {
            // handle this somehow
        }
    }
