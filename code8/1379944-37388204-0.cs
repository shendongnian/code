    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace GridAddRow {
    
      public partial class MainWindow: Window {
    
        int textCol, comboBoxCol, buttonCol;
    
        public MainWindow() {
          InitializeComponent();
    
          //initialise MainGrid, i.e. define columns, could be done in XAML
          addCol(out textCol, new GridLength(100));
          addCol(out comboBoxCol, GridLength.Auto);
          addCol(out buttonCol, GridLength.Auto);
    
          //initialise grid content, usually read from a db
          addRow("Some Text", 1);
          addRow("Another String", 3);
    
          AddButton.Click += AddButton_Click;
        }
    
        private void addCol(out int textCol, GridLength gridLength) {
          textCol = MainGrid.ColumnDefinitions.Count;
          MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = gridLength });
        }
    
        List<TextBox> textBoxes = new List<TextBox>();
        List<ComboBox> comboBoxes = new List<ComboBox>();
    
        private void addRow(string textBoxString, int comboBoxIndex) {
          int rowId = MainGrid.RowDefinitions.Count;
          MainGrid.RowDefinitions.Add(new RowDefinition());
    
          TextBox textBox = new TextBox { Text = textBoxString };
          textBoxes.Add(textBox);
          addControl(textBox, rowId, textCol);
          textBox.TextChanged += TextBox_TextChanged;
    
          ComboBox comboBox = new ComboBox {SelectedIndex= comboBoxIndex };
          comboBox.Items.Add(new ComboBoxItem {Content="0" });
          comboBox.Items.Add(new ComboBoxItem { Content="1" });
          comboBox.Items.Add(new ComboBoxItem { Content="2" });
          comboBox.Items.Add(new ComboBoxItem { Content="3" });
          comboBoxes.Add(comboBox);
          addControl(comboBox, rowId, comboBoxCol);
          comboBox.SelectionChanged += ComboBox_SelectionChanged;
    
          Button deleteRowButton = new Button {Content = "Delete"};
          addControl(deleteRowButton, rowId, buttonCol);
          deleteRowButton.Click += DeleteRowButton_Click;
        }
    
        private void addControl(Control control, int rowId, int textCol) {
          control.Tag = rowId;
          MainGrid.Children.Add(control);
          Grid.SetRow(control, rowId);
          Grid.SetColumn(control, textCol);
        }
    
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {
          TextBox textbox = (TextBox)sender;
          int rowid = (int)textbox.Tag;
          //do something here. 
        }
    
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
          ComboBox comboBox = (ComboBox)sender;
          int rowid = (int)comboBox.Tag;
          //do something here. 
        }
    
        private void DeleteRowButton_Click(object sender, RoutedEventArgs e) {
          Button deleteButton = (Button)sender;
          int rowid = (int)deleteButton.Tag;
          MainGrid.Children.Remove(deleteButton);
    
          TextBox textbox = textBoxes[rowid];
          MainGrid.Children.Remove(textbox);
          textBoxes.RemoveAt(rowid);
    
          ComboBox comboBox = comboBoxes[rowid];
          MainGrid.Children.Remove(comboBox);
          comboBoxes.RemoveAt(rowid);
        }
    
        private void AddButton_Click(object sender, RoutedEventArgs e) {
          addRow("", 1);
        }
      }
    }
