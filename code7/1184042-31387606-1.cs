    public class SlowProcess {
      ...
      // Simplest, not thread safe
      public static event EventHandler<int> StepChanged;
    
      public static void DoSomething() {
        for (int nStep = 0; nStep < 100; nStep++) {
          if (null != StepChanged)
            StepChanged(null, nStep);
    
          SlowStep(nStep);
        } 
      }
    }
    
    ...
    
    public partial class MyEventForm: Form {
      ...    
      private void onStepChange(Object sender, int nStep) {
        //TODO: update form here after receiving a feedback 
      }
    
      private void TraceSlowProcess() {
        // feedback is required 
        SlowProcess.StepChanged += onStepChange;
    
        try {
          SlowProcess.DoSomething(); 
        }
        finally {
          // No need of feedback
          SlowProcess.StepChanged -= onStepChange;
        }
      }
    } 
