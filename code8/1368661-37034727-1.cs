    public class MyActivity : MvxActivity<MyViewModel>
    {
        public void OnCreate(Bundle _)
        {
            base.OnCreate(_);
            ViewModel.ShowTaskCommandAction = () => {
                var dialogFragment = new ProjectMyTaskDialog() {
                    DataContext = task
                });
                dialogFragment.Show(FragmentManager);
            };
    
            // whatever else code
        }
    }
