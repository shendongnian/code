        public static void SetDefaultStyle(this IContainer contr, MetroColorStyle style)
        {
            MetroStyleManager manager = FindManager(contr);
            manager.Style = style;
        }
        public static void SetDefaultTheme(this IContainer contr, MetroThemeStyle thme)
        {
            MetroStyleManager manager = FindManager(contr);
            manager.Theme = thme;
        }
        private static MetroStyleManager FindManager(IContainer contr)
        {
            MetroStyleManager manager = new MetroStyleManager(contr);
            foreach (IComponent item in contr.Components)
            {
                if (item is MetroStyleManager)
                {
                    manager = (MetroStyleManager)item;
                }
            }
            return manager;
        }
