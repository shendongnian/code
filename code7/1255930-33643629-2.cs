    private void Update_ViewModel(global::UWP.BaseViewModel obj, int phase)
    {
        if (obj != null)
        {
            if ((phase & (NOT_PHASED | (1 << 0))) != 0)
            {
                this.Update_ViewModel__local_MyPage+MyViewModel_Title_(((global::UWP.MyPage.MyViewModel)(obj)).Title, phase);
            }
        }
    }
    private void Update_ViewModel__local_MyPage+MyViewModel_Title_(global::System.String obj, int phase)
    {
        if((phase & ((1 << 0) | NOT_PHASED )) != 0)
        {
            XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj2, obj, null);
        }
    }
