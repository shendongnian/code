            Action action = () => o.GetType().GetMethod(n).Invoke(o, args);
            var controlMaps = new Func<object, Control>[]
            {
                x => x as Control,
                x => o is ControlCollection ? (o as ControlCollection).Owner : null,
            };
            var c = controlMaps
                    .Select(m => m(o))
                    .Where(x => x != null)
                    .FirstOrDefault();
            if (c != null)
            {
                c.Invoke(action);
            }
            else
            {
                action();
            }
