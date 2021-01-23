    public partial class PostTravelWizardWebPartUserControl : UserControl
    {
        public static void GeneratePDF(PostTravelData ptd)
        {
            ;//bla
        }
    }
    public class PostTravelItemEventReceiver : SPItemEventReceiver
    {
        base.ItemAdded(properties);
        PostTravelWizardWebPartUserControl.GeneratePDF();
    }
