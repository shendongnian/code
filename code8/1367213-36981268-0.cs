    using NUnit.Framework;
    using System;
    
    namespace NUnitTest
    {
        [SetUpFixture]
        public class GlobalSetup
        {
            // The setup fixture seems to be bugged somewhat.
            // Therefore we manually check if we've run before.
            static bool WeHaveRunAlready = false;
    
            [SetUp]
            public void ImportConfigurationData ()
            {
                if (WeHaveRunAlready)
                    return;
    
                WeHaveRunAlready = true;
                
                // Do my setup stuff here ...
            }
        }
    }
