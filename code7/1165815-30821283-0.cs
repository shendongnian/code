    private void BindData(int visitorId)
    {
        using (var context = SampleContext.GetContext())
        {
            var visitor = context.Visitors.FirstOrDefault(x => x.VisitorId == visitorId);
            MyCalender.DataContext = visitor;
        }
    }
    private void BtnBindDate_OnClick(object sender, RoutedEventArgs e)
    {
        var id = int.Parse(TxtVisitorId.Text);
        BindData(id);
    }
    
