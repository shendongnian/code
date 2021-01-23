    public class MyButtonEventArgs : EventArgs{
        public --WhateverProgressbarTypeIs-- Bar {get;set;}
    }
    
    ProgressTimerList[i].Button.Reset += (sender, e) => Button_Reset(sender, new MyEventArgs { Bar = ProgressTimerList[i].Progressbar });
    void Button_Reset(object sender, MyButtonEventArgs e)
    {
        var wunderBar = e.Bar;
    }
