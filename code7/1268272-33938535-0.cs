    Table1.Invoke(new MethodInvoker(delegate()
    {
        ((ProgressBar)Table1.Controls[<progressbar_name>]).Value = <percentage>;
        ((ProgressBar)Table1.Controls[<progressbar_name>]).Style = ProgressBarStyle.Marquee;
    }));
