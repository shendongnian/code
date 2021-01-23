    // group shapes into batches
    const int batchSize = 100;
    var batches = ShapeList.Select((item, index) => new { index = index, item = item })
        .GroupBy(item => item.index / batchSize)
        .ToArray();
    // function to create a local closure for each batch
    Action<int> addBatch = batchNumber => {
        var batch = batches[batchNumber];
        Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
        {
            foreach (var shape in batch)
            {
                drawingCanvas.Children.Add(shape.item);
            };
            if (batchNumber >= batches.Length - 1)
                drawingCanvas.Visibility = Visibility.Visible;
        }));
    };
    drawingCanvas.Visibility = Visibility.Collapsed;
    for (int i=0 ; i < batches.Length ; i++)
    {
        addBatch(i);
    }
