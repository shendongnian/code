    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    namespace StackOverflow
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                _jobs = new ObservableCollection<JobModel>
                {
                    new JobModel { EmployeeName = "Fred" },
                    new JobModel { EmployeeName = "Wilma" },
                    new JobModel { EmployeeName = "Fred" },
                    new JobModel { EmployeeName = "Barney" },
                    new JobModel { EmployeeName = "Betty" },
                };
                JobsCollectionView = CollectionViewSource.GetDefaultView(_jobs);
                DataContext = this;
            }
            readonly ObservableCollection<JobModel> _jobs;
            public ICollectionView JobsCollectionView { get; private set; }
            void OnCheckBoxClick(object sender, RoutedEventArgs e)
            {
                var checkedEmployees = new HashSet<string>();
                foreach (CheckBox checkBox in _employees.Children)
                {
                    if (checkBox.IsChecked == true)
                    {
                        checkedEmployees.Add((string) checkBox.Content);
                    }
                }
                JobsCollectionView.Filter =
                    job => checkedEmployees.Contains((job as JobModel).EmployeeName);
            }
        }
    }
