    public class EpisodeViewModel
    {
        private readonly IEpisodeModel episodeModel;
        private readonly IViewFinder viewFinder;
        public EpisodeViewModel(IEpisodeModel episodeModel, IViewFinder viewFnder)
        {
            this.episodeModel = episodeModel;
            this.viewFinder = viewFinder;
            CheckLoginPassed(this.episodeModel.LoginPassed);
        }
        private CheckLoginPassed(bool loginPassed)
        {
            if (!loginPassed)
            {
                this.viewFinder.LoadView<ILoginView>();
            }
        }
    }
