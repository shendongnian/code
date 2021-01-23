    [Test]
    public void Should_be_scrollable()
    {
        var ControlToTest = new MyControl();
        var scrollViewer = new ScrollViewer
        {
            Content = ControlToTest,
            CanContentScroll = true
        };
        var window = new Window { Content = scrollViewer };
        window.Show();
        Assert.That(ControlToTest, Is.InstanceOf<IScrollInfo>());
        Assert.That(ControlToTest.ScrollOwner, Is.SameAs(scrollViewer));
    }
