    public class ChildPresenter : BasePresenter<IChildView>, IChildPresenter
        {
    
           public bool Ask()
           {
                this.Init();
                bool res = View.ShowAsDialog();
                ApplicationController.ClearInstance<IChildView>();
                return res;
           }
    
            public override void Init()
            {
                View.MDIparent = ApplicationController.GetMainFrom<IMainPresenter>();
                base.Init();
            }
        }
