     private void ClearIsEnabledEvent()
        {
            FieldInfo handlerInfo = typeof(HwndHost).GetField("_handlerEnabledChanged", BindingFlags.Instance | BindingFlags.NonPublic);
            // can't do this, HwndHost needs it to be NOT null
            //handlerInfo.SetValue(this,null);
            // replace functionality with my own code (adjust\fix for my own context)
            //handlerInfo.SetValue(this, new DependencyPropertyChangedEventHandler(OnEnabledChanged));
            // in this case, it doesn't appear anything implementation is needed
            // just an empty delegate
            if (handlerInfo != null)
                handlerInfo.SetValue(this, new DependencyPropertyChangedEventHandler(delegate { }));
        }
