        public static T CreateControlInstance<T>(int x, int y, int w, int h) where T : Control, new()
        {
            T c = new T();
            c.Location = new Point(x, y);
            c.Size = new Size(w, h);
            return c;
        }
        private main()
        {
            TextBox t = CreateControlInstance<TextBox>(1, 1, 100, 100);
        }
