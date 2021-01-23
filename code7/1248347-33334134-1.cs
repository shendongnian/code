    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Media;
    using System.ComponentModel;
    
    namespace WPF.Tutorial
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public static Regex SearchRegex = new Regex("(segment)", RegexOptions.IgnoreCase);
            public static Regex TagRegex = new Regex("(<[^>]*>)", RegexOptions.IgnoreCase);
    
            ObservableCollection<Segment> segments;
    
            public MainWindow()
            {
                InitializeComponent();
                segments = new ObservableCollection<Segment>();
                testGrid.ItemsSource = segments;
                for (int i = 1; i <= 100; i++)
                {
                    segments.Add(new Segment()
                    {
                        ID = i.ToString(),
                        SourceText = String.Format("Segment <b>{0}</b>", i),
                        TargetText = String.Format("Сегмент <b>{0}</b>", i)
                    });
                }
                statusLabel.Content = String.Format("Items: {0}", testGrid.Items.Count);
            }
    
    
            public class Segment : IEditableObject
            {
                string targetBackup = null;
    
                public string ID { get; set; }
                public string SourceText { get; set; }
                public string TargetText { get; set; }
    
                public void BeginEdit()
                {
                    if (targetBackup == null)
                        targetBackup = TargetText;
                }
    
                public void CancelEdit()
                {
                    if (targetBackup != null)
                    {
                        TargetText = targetBackup;
                        targetBackup = null;
                    }
                }
    
                public void EndEdit()
                {
                    if (targetBackup != null)
                        targetBackup = null;
                }
            }
        }
    
    
        public class RichTextBlock : TextBlock
        {
            public static DependencyProperty InlineProperty;
    
            static RichTextBlock()
            {
                //OverrideMetadata call tells the system that this element wants to provide a style that is different than in base class
                DefaultStyleKeyProperty.OverrideMetadata(typeof(RichTextBlock), new FrameworkPropertyMetadata(
                                    typeof(RichTextBlock)));
                InlineProperty = DependencyProperty.Register("RichText", typeof(List<Inline>), typeof(RichTextBlock),
                                new PropertyMetadata(null, new PropertyChangedCallback(OnInlineChanged)));
            }
            public List<Inline> RichText
            {
                get { return (List<Inline>)GetValue(InlineProperty); }
                set { SetValue(InlineProperty, value); }
            }
    
            public static void OnInlineChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                if (e.NewValue == e.OldValue)
                    return;
                RichTextBlock r = sender as RichTextBlock;
                List<Inline> i = e.NewValue as List<Inline>;
                if (r == null || i == null)
                    return;
                r.Inlines.Clear();
                foreach (Inline inline in i)
                {
                    r.Inlines.Add(inline);
                }
            }
        }
    
    
        class RichTextValueConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                string text = value as string;
                var inlines = new List<Inline>();
                if (text != null)
                {
                    string[] pieces = MainWindow.TagRegex.Split(text);
                    var subpieces = new List<string>();
                    foreach (var piece in pieces)
                    {
                        subpieces.AddRange(MainWindow.SearchRegex.Split(piece));
                    }
                    foreach (var item in subpieces)
                    {
                        if (MainWindow.SearchRegex.Match(item).Success && !MainWindow.TagRegex.Match(item).Success)
                        {
                            Run runx = new Run(item);
                            runx.Background = Brushes.Yellow;
                            inlines.Add(runx);
                        }
                        else if (MainWindow.TagRegex.Match(item).Success)
                        {
                            Run runx = new Run(item);
                            runx.Foreground = Brushes.Red;
                            inlines.Add(runx);
                        }
                        else
                        {
                            inlines.Add(new Run(item));
                        }
                    }
                }
                return inlines;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException("Back conversion is not supported!");
            }
        }
    }
