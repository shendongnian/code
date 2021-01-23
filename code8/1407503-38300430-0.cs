        private double[,] _CellSizeArray;
        private double[] _ColumnSize;
        //Only call once!
        private void CalculateCellSizeArray()
        {
            try
            {
                _CellSizeArray = new double[this.Columns.Count, this.Items.Count];
                foreach (object item in this.Items)
                {
                    DataGridRow row = this.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    DataGridCellsPresenter presenter = Helper.VisualTree.GetVisualChild<DataGridCellsPresenter>(row);
                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                        if (cell == null)
                        {
                            this.UpdateLayout();
                            this.ScrollIntoView(this.Columns[i]);
                            cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                        }
                        TextBlock textBlock = Helper.VisualTree.GetVisualChild<TextBlock>(cell);
                        DependencyPropertyDescriptor dp = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(TextBlock));
                        dp.AddValueChanged(textBlock, (object a, EventArgs b) =>
                        {
                            Size s = MeasureTextSize(textBlock.Text, textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch, textBlock.FontSize);
                            _CellSizeArray[i, row.GetIndex()] = s.Width;
                        });
                        Size size = MeasureTextSize(textBlock.Text, textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch, textBlock.FontSize);
                        _CellSizeArray[i, row.GetIndex()] = size.Width;
                    }
                }
                CalculateColumnSize();
            }
            catch (Exception exception)
            {
                
            }
        }
        private void CalculateColumnSize()
        {
            _ColumnSize = new double[this.Columns.Count];
            for (int column = 0; column < _CellSizeArray.GetLength(0); column++)
            {
                for (int row = 0; row < _CellSizeArray.GetLength(1); row++)
                {
                    if (_CellSizeArray[column, row] > _ColumnSize[column])
                        _ColumnSize[column] = _CellSizeArray[column, row];
                }
            }
        }
        /// <summary>
        /// Get the required height and width of the specified text. Uses FortammedText
        /// </summary>
        public static Size MeasureTextSize(string text, FontFamily fontFamily, FontStyle fontStyle, FontWeight fontWeight, FontStretch fontStretch, double fontSize)
        {
            FormattedText ft = new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(fontFamily, fontStyle, fontWeight, fontStretch), fontSize, Brushes.Black);
            return new Size(ft.Width, ft.Height);
        }
        /// <summary>
        /// Get the required height and width of the specified text. Uses Glyph's
        /// </summary>
        public static Size MeasureText(string text, FontFamily fontFamily, FontStyle fontStyle, FontWeight fontWeight, FontStretch fontStretch, double fontSize)
        {
            Typeface typeface = new Typeface(fontFamily, fontStyle, fontWeight, fontStretch);
            GlyphTypeface glyphTypeface;
            if (!typeface.TryGetGlyphTypeface(out glyphTypeface))
            {
                return MeasureTextSize(text, fontFamily, fontStyle, fontWeight, fontStretch, fontSize);
            }
            double totalWidth = 0;
            double height = 0;
            for (int n = 0; n < text.Length; n++)
            {
                ushort glyphIndex = glyphTypeface.CharacterToGlyphMap[text[n]];
                double width = glyphTypeface.AdvanceWidths[glyphIndex] * fontSize;
                double glyphHeight = glyphTypeface.AdvanceHeights[glyphIndex] * fontSize;
                if (glyphHeight > height)
                {
                    height = glyphHeight;
                }
                totalWidth += width;
            }
            return new Size(totalWidth, height);
        } 
