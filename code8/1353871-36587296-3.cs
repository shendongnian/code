    using System;
    using Xamarin.Forms;
    using System.Collections.Generic;
    namespace FormsSandbox
    {
        public partial class XamlPage : ContentPage
        {
            private double _colSize = 0.0;
            private List<ColumnDefinition> _columns = new List<ColumnDefinition>();
            public XamlPage ()
            {
                InitializeComponent ();
                var data = new List<string> ();
                data.Add ("Lorem ipsum");
                data.Add ("Foo");
                data.Add ("Dolor semet");
                data.Add ("Test");
                data.Add (".");
                data.Add ("Xamarin Forms Is Great");
                data.Add ("Short");
                data.Add ("Longer than Short");
                data.Add ("");
                data.Add ("Hyphenated");
                data.Add ("Non-hyphenated");
                data.Add ("Ironic, eh?");
                MyLV.ItemsSource = data;
            }
            public void LabelSizeChanged (object sender, EventArgs e)
            {
                var label = (Label)sender;
                var grid = (Grid)label.Parent;
                var column = grid.ColumnDefinitions [0];
                if (!_columns.Contains (column)) {
                    _columns.Add (column);
                }
                var adjustments = new List<ColumnDefinition> ();
                if (label.Width > _colSize) {
                    _colSize = label.Width;
                    adjustments.AddRange (_columns);
                } else {
                    adjustments.Add (column);
                }
                foreach (var col in adjustments) {
                    col.Width = new GridLength (_colSize);
                }
            }
        }
    }
