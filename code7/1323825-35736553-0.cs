    // using PropertyDependencyDemo.Mvvm;
    // ... use the namespace above that contains the ObservableExtensions class
    ModelView1
        .WhenPropertyChanges((a) => a.SettingX)
        .AlsoInvokeAction(() => ModelView2.SettingX = ModelView1.SettingX);
