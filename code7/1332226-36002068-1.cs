    [Activity(ParentActivity = typeof(HomeView), Theme = "@style/Theme.App", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class PlanningView : BaseTabActivity<PlanningViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.page_planning);
            ViewModel.BuildInterface();
            CreateTabs();
        }
        void CreateTabs()
        {
            TabHost.TabSpec spec;
            spec = TabHost.NewTabSpec(ViewModel.TextSource.GetText(LocalizationConstants.Planning_Stats));
            spec.SetIndicator(ViewModel.TextSource.GetText(LocalizationConstants.Planning_Stats));
            var intent = new Intent(this.CreateIntentFor(ViewModel.PlanningStats));
            spec.SetContent(intent.AddFlags(ActivityFlags.ClearTop));
            TabHost.AddTab(spec);
            var currentGameweek = ViewModel.CurrentGW;
            foreach (var planningGW in ViewModel.PlanningGW)
            {
                spec = TabHost.NewTabSpec(string.Format("{0}{1}", ViewModel.SharedTextSource.GetText(LocalizationConstants.Shared_GW), planningGW.Gameweek));
                spec.SetIndicator(string.Format("{0}{1}", ViewModel.SharedTextSource.GetText(LocalizationConstants.Shared_GW), planningGW.Gameweek));
                intent = new Intent(this.CreateIntentFor(planningGW));
                spec.SetContent(intent.AddFlags(ActivityFlags.ClearTop));
                TabHost.AddTab(spec);
            }
        }
    }
