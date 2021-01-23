    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    namespace SimpleDataGrid
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new List<Person>
                {
                    new Person{Name = "Tom", Age = 10},
                    new Person{Name = "Ken", Age = 20},
                    new Person{Name = "Jen", Age = 30}
                };
                dgOutput.Items.Add(new Person { Name = "Tom", Age = 10 });
                dgOutput.Items.Add(new Person { Name = "Ken", Age = 20 });
                dgOutput.Items.Add(new Person { Name = "Jen", Age = 30 });
                dgOutput.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") });
                dgOutput.Columns.Add(new DataGridTextColumn { Header = "Age", Binding = new Binding("Age") });
            }
        }
        public class Person
        {
            public string Name { set; get; }
            public int Age { set; get; }
        }
    }
