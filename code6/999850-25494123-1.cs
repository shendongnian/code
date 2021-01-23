    public class SelectAll : TargetedTriggerAction<List<MyClass>>
    {
        protected override void Invoke(object parameter)
        {
            if (Target is List<MyClass>)
                foreach (var elem in (List<MyClass>)Target)
                    elem.Selected = true;
        }
    }
