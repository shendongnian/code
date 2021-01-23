    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace NQR_GUI_WPF
    {
        /// <summary>
        /// Interaction logic for ImageButton.xaml
        /// </summary>
        public class ImageButton : Button
        {
            public ImageButton()
            {
                TouchDown += ImageButton_TouchDown;
            }
            static ImageButton()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
            }
            private void ImageButton_TouchDown(object sender, TouchEventArgs e)
            {
                Keyboard.ClearFocus();
            }
            #region Dependency Properties
            public static DependencyProperty ClickedContentProperty = DependencyProperty.Register("ClickedContent", typeof(Object), typeof(ImageButton));
            public static DependencyProperty HighlightedContentProperty = DependencyProperty.Register("HighlightedContent", typeof(Object), typeof(ImageButton));
            public Object ClickedContent
            {
                get { return (Object)base.GetValue(ClickedContentProperty); }
                set { base.SetValue(ClickedContentProperty, value); }
            }
            public Object HighlightedContent
            {
                get { return (Object)base.GetValue(HighlightedContentProperty); }
                set { base.SetValue(HighlightedContentProperty, value); }
            }
            #endregion Dependency Properties
        }
    }
