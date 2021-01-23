    bool ok =
        a.IsDisabledOrEmpty()
    &&  b.IsDisabledOrEmpty()
    &&  c.IsDisabledOrEmpty()
    &&  (a.IsEnabled || b.IsEnabled || c.IsEnabled)
    &&  d.IsDisabledOrEmpty()
    &&  f.IsDisabledOrEmpty();
