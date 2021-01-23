    public sealed partial class FreeTraining : Page
    {
        FreeTrainingViewModel FreeTrainingViewModel;
        public FreeTraining()
        {               
            this.InitializeComponent();
            FreeTrainingViewModel = (FreeTrainingViewModel)gridName.FindResource("FreeTrainingViewModel");
        } //Method for adding +1 to the pushupsCount "FreeTrainingViewModel.PushupsCount+1;"
}
