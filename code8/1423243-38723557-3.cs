        using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace DataGrid_Status
    {
        /// <summary>
        /// Interaction logic for Window4.xaml
        /// </summary>
        public partial class Window4 : Window
        {
            public Window4()
            {
                InitializeComponent();
                List<MyClass> lst = new List<MyClass>();
                for (int i = 0; i < 10; i++)
                {
                    MyClass obj = new MyClass();
                    obj.Name = "Name" + i;
                    if (i == 1)
                    {
                        obj.Status=StatusEnum.Success;
                    }
                    else if (i == 2)
                    {
                        obj.Status = StatusEnum.Failed;
                    }
                    else
                    {
                        obj.Status = StatusEnum.InProgress;
                    }
                    lst.Add(obj);
                }
                DataGrid.ItemsSource = lst;
            }
        }
    
        class StatusConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                StatusEnum status = (StatusEnum)value;
                string param = parameter as string;
                if ((status == StatusEnum.Success && param == "a")|| (status == StatusEnum.InProgress && param == "b")|| (status == StatusEnum.Failed && param == "c"))
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
        class MyClass
        {
            public string Name { get; set; }
            public StatusEnum Status { get; set; }
        }
    
        enum StatusEnum
        {
            Success,
            Failed,
            InProgress
        }
    }
