    List<Rectangle> MaskBlocks = new List<Rectangle>();
    foreach (StackPanel gr in FindVisualChildren<StackPanel>(Container))
    if (gr.Tag!= null && gr.Tag.ToString() == "Blur")
    {
        System.Windows.Point tmp = gr.TransformToAncestor(this).Transform(new System.Windows.Point(0, 0));
        MaskBlocks.Add(new System.Drawing.Rectangle(new System.Drawing.Point((int)tmp.X,(int)tmp.Y), new System.Drawing.Size((int)gr.ActualWidth, (int)gr.ActualHeight)));
    }
