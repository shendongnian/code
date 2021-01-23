    var e1 = new EventTrigger(UIElement.MouseEnterEvent);
    //add actions for e1
    e1.Actions.Add(new BeginStoryboard{ Storyboard = _ExpandStory});
    var e2 = new EventTrigger(UIElement.MouseLeaveEvent);
    //add actions for e2
    e2.Actions.Add(new BeginStoryboard { Storyboard = _ShrinkStory});
    //add the 2 event triggers
    _Image.Triggers.Add(e1);
    _Image.Triggers.Add(e2);
