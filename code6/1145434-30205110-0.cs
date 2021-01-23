            Action action = () => o.GetType().GetMethod(n).Invoke(o, args);
            if (o is Control)
            {
                var c = o as Control;
                c.Invoke(action);
            }
            else if (o is ControlCollection)
            {
                var c = (o as ControlCollection).Owner;
                c.Invoke(action);
            }
            else
            {
                action();
            }
