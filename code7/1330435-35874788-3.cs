            Delegate action1 = new Action(DoStuff);
            Delegate action2 = new Action<int>(DoStuff2);
            var myActions = new Dictionary<Delegate, object[]>();
            myActions.Add(action1, null);
            myActions.Add(action2, new object[] { 0 });
            foreach (var action in myActions)
            {
                action.Key.DynamicInvoke(action.Value);
            }
