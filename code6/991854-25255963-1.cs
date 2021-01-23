        class AnimationHelper : DependencyObject
        {
            // Using a DependencyProperty as the backing store for IsNonRegularCell.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty IsNonRegularCellProperty =
                DependencyProperty.RegisterAttached("IsNonRegularCell", typeof(bool), typeof(AnimationHelper), new PropertyMetadata(false, OnIsNonRegularCellChanged));
            private static void OnIsNonRegularCellChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                Rectangle rect = d as Rectangle;
                if ((bool)e.NewValue)
                {
                    //to make sure I set the color values again
                    rect.Stroke = new SolidColorBrush(Colors.Silver);
                    rect.Fill = new SolidColorBrush(Colors.Transparent);
                    rect.SetValue(HoverCountProperty, default(byte));
                    rect.MouseEnter += rect_MouseEnter;
                }
                else
                {
                    rect.MouseEnter -= rect_MouseEnter;
                }
            }
            static void rect_MouseEnter(object sender, MouseEventArgs e)
            {
                Rectangle rect = sender as Rectangle;
                byte hoverCount = (byte)rect.GetValue(HoverCountProperty);
                hoverCount++;
                if (hoverCount > 3)
                    return;
                rect.SetValue(HoverCountProperty, hoverCount);
                byte alpha = (byte)(85 * hoverCount);
                ColorAnimation anim = new System.Windows.Media.Animation.ColorAnimation(Color.FromArgb(alpha, 0x66, 0xcc, 0), TimeSpan.FromSeconds(0));
                rect.Fill.BeginAnimation(SolidColorBrush.ColorProperty, anim);
                rect.Stroke.BeginAnimation(SolidColorBrush.ColorProperty, anim);
            }
            // Using a DependencyProperty as the backing store for HoverCount.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty HoverCountProperty =
                DependencyProperty.RegisterAttached("HoverCount", typeof(byte), typeof(AnimationHelper), new PropertyMetadata(default(byte)));
        }
