      public Dictionary<string, SolidColorBrush> Colors
            {
                get
                {
                    var _Colors = typeof(Windows.UI.Colors)
                        // using System.Reflection;
                        .GetRuntimeProperties()
                        .Select(c => new
                        {
                            Color = new SolidColorBrush((Windows.UI.Color)c.GetValue(null)),
                            Name = c.Name
                        });
    
                    return _Colors.ToDictionary(x => x.Name, x => x.Color);
                }
            }
