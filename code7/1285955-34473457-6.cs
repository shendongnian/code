        class MyAction {
           public int c { get; set; }
           public string t { get; set; }
           public MyAction(Controls control) {
              c = (int)control;
              t = control.ToString();
           }
        }
        var actions = new List<MyAction>();
        foreach (var control in controls)
           actions.Add(new MyAction(control));
