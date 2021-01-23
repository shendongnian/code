    protected override void OnRestoreInstanceState(IParcelable state)
            {
                var bundle = state as Bundle;
                if (bundle != null)
                {
                    mCurrentPage = bundle.GetInt("currentPage", 0);
                    mSnapPage = mCurrentPage;
                    state = (IParcelable)bundle.GetParcelable("superState");
                }
                base.OnRestoreInstanceState(state);
                RequestLayout();
            }
    
            protected override IParcelable OnSaveInstanceState()
            {
                var bundle = new Bundle();
                bundle.PutParcelable("superState", base.OnSaveInstanceState());
                bundle.PutInt("currentPage", mCurrentPage);
                return bundle;
            }
