        public MainWindow()
        {
            InitializeComponent();
            PopulateTableInsertMenuItem(10, 8, 15, 15, 2);
        }
        private void ResetTableCellRectangles()
        {
            foreach (Rectangle r in InsertTblCellMnuItemContainer.Children)
            {
                r.Fill = Brushes.AliceBlue;
                r.Stroke = Brushes.Black;
            }
        }
        private void InsertTblCellMnuItemContainer_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = e.GetPosition(InsertTblCellMnuItemContainer);
            foreach (Rectangle r in InsertTblCellMnuItemContainer.Children)
            {
                Vector posRect = VisualTreeHelper.GetOffset(r);
                if ((posRect.X <= pos.X) && (posRect.Y <= pos.Y))
                {
                    r.Fill = Brushes.LightYellow;
                    r.Stroke = Brushes.Orange;
                }
                else
                {
                    r.Fill = Brushes.AliceBlue;
                    r.Stroke = Brushes.Black;
                }
            }
        }
        private void InsertTblCellMnuItemContainer_MouseLeave(object sender, MouseEventArgs e)
        {
            ResetTableCellRectangles();
            _rgcInsertTable.Header = "Inserir tabela";
        }
        private void PopulateTableInsertMenuItem(int width, int height, int rectWidth, int rectHeight, int margin)
        {
            Rectangle r;
            InsertTblCellMnuItemContainer.Width = (rectWidth + margin) * width;
            InsertTblCellMnuItemContainer.Height = (rectHeight + margin) * height;
            for (int j = 0; j < height; ++j)
            {
                for (int i = 0; i < width; ++i)
                {
                    // Create new rectangle
                    r = new Rectangle
                    {
                        Width = rectWidth,
                        Height = rectHeight,
                        Stroke = Brushes.Black,
                        Fill = Brushes.AliceBlue,
                        Tag = new Point(i + 1, j + 1),  // Remember rectangle's position in grid somehow
                    };
                    r.MouseLeftButtonDown += new MouseButtonEventHandler(TableInsertRectangle_MouseLeftButtonDown);
                    r.MouseEnter += new MouseEventHandler(TableInsertRectangle_MouseEnter);
                    // Set position in canvas
                    Canvas.SetLeft(r, (i * margin) + (i * rectWidth));
                    Canvas.SetTop(r, (j * margin) + (j * rectHeight));
                    // Add rectangle to canvas
                    InsertTblCellMnuItemContainer.Children.Add(r);
                }
            }
        }
        void TableInsertRectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            Point rectKoords = (Point)((Rectangle)sender).Tag;
            _rgcInsertTable.Header = rectKoords.X.ToString() + "x" + rectKoords.Y.ToString() + " tabela";
        }
        void TableInsertRectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point rectKoords = (Point)((Rectangle)sender).Tag;
            _textControl.Tables.Add((int)rectKoords.Y, (int)rectKoords.X);
        }
