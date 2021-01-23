    private void Loop(object o)
    {
        Tuple<int, int> indices = o as Tuple<int, int>;
        for(int i = indices.Item1; i <= indices.Item2; ++i)
        {
            myList[i].foo.DoCalc();
            if (myList[i].ellipse == null)
                continue;
            
            int iLocal = i;
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => myList[iLocal].ellipse.Fill = Brushes.Black));
        }
    }
