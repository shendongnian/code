    public static void DisruptionDisplayNamePropertyCallback(DependencyObject dp, DependencyPropertyChangedEventArgs args)
    {
        var iconDisplayName = ((DisruptionIcon)dp).DisplayName;
        //You should comment this
        //if (iconDisplayName == null)
            //return;
        ((DisruptionIcon)dp).DisplayName = iconDisplayName;
    }
