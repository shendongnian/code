      using System;
      using System.Collections.Generic;
      using System.Collections.ObjectModel;
      using System.Linq;
      using System.Windows;
    
      namespace WpfApplication8
      {
        class TestRunnerControlViewModel 
        {
            //  private DomainFacade domainFacade;
            public TestRunnerControlViewModel()
            {
                //domainFacade = ((App)Application.Current).DomainFacade;
            }
    
            public IEnumerable<string> EnvironmentVersions
            {
                get
                {
                    return new List<string>() { "test", "test2" };
                }
            }
        }
      }
     
