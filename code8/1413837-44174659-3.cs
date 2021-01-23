    public class MainControl  :IMainControl
        {
            [Resolve]
          public IApplicationController applicationController;
          public void OnOpenChildForm()
          {
           IChildControl TransfersOnTheWayControl = applicationController.Resolve<IChildControl>();
           TransfersOnTheWayControl.Run();
          }
        }
