    <Window x:Class="WpfDemo.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfDemo"
            xmlns:xctk="http://schemas.xceed.com/wpf/xaml/toolkit"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
          <xctk:PropertyGrid x:Name="It" />
        </Grid>
    </Window>
-
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    namespace WpfDemo
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
          It.SelectedObject = new MainWindowViewModel().BindingComplexObject;
        }
      }
    }
