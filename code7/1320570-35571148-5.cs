    ColumnText ct = new ColumnText(cb);
    ct.AddElement(list);
    Rectangle rect = new Rectangle(36, 36, 559, 806);
    ct.SetSimpleColumn(rect);
    int status = ct.Go();
    while (ColumnText.HasMoreText(status)) {
        document.NewPage();
        ct.SetSimpleColumn(rect);
        ct.Go();
    }
