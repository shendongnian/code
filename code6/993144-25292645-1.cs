    public static class ControlExtensions
        {
            public static IEnumerable<T> GetAllControlsOfType<T>(this Control parent) where T : Control
            {
                var result = new List<T>();
                foreach (Control control in parent.Controls)
                {
                    if (control is T)
                    {
                        result.Add((T)control);
                    }
                    if (control.HasControls())
                    {
                        result.AddRange(control.GetAllControlsOfType<T>());
                    }
                }
                return result;
            }
        }
