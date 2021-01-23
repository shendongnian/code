    bool ok =
        a.IsDisabledOrNotEmpty()
    &&  b.IsDisabledOrNotEmpty()
    &&  c.IsDisabledOrNotEmpty()
    &&  (a.IsEnabled || b.IsEnabled || c.IsEnabled)
    &&  d.IsDisabledOrNotEmpty()
    &&  f.IsDisabledOrNotEmpty();
