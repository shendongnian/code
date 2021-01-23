    var tabs = tabControl.TabPages.OfType<TabPage>().ToArray();
    var bringForward = tabs.Skip(15).Take(8);
    tabs = tabs.Take(5)
               .Union(bringForward)
               .Union(tabs)
               .ToArray();
    tabControl.TabPages.Clear();
    tabControl.TabPages.AddRange(tabs);
