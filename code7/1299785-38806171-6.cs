    public static class MyExtensions
        {
            public static void SetDefaultStyle(this IContainer contr, MetroForm owner, MetroColorStyle style)
            {
                MetroStyleManager manager = FindManager(contr, owner);
                manager.Style = style;
                owner.Style = style;
            }
            public static void SetDefaultTheme(this IContainer contr, MetroForm owner, MetroThemeStyle thme)
            {
                MetroStyleManager manager = FindManager(contr, owner);
                manager.Theme = thme;
            }
            private static MetroStyleManager FindManager(IContainer contr, MetroForm owner)
            {
                MetroStyleManager manager = null;
                foreach (IComponent item in contr.Components)
                {
                    if (((MetroStyleManager)item).Owner == owner)
                    {
                        manager = (MetroStyleManager)item;
                    }
                }
                return manager;
            }
        }
