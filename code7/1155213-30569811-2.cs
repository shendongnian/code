    var scrollViewer = new ScrollViewer
    {
        Content = ControlToTest,
        CanContentScroll = true,
        VerticalScrollBarVisibility = ScrollBarVisibility.Auto
    };
    var window = new Window { Content = scrollViewer, Height = 600 };
    window.Show();
    Assert.That(
        ControlToTest.ScrollOwner.ComputedVerticalScrollBarVisibility,
        Is.EqualTo(Visibility.Collapsed));
    window.Height = 300;
    Render();
    Assert.That(
        ControlToTest.ScrollOwner.ComputedVerticalScrollBarVisibility,
        Is.EqualTo(Visibility.Visible));
