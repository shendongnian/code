    <Window x:Class="WpfControlTemplates._32794074.Win32794074"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="Win32794074" Height="600" Width="1000">
        
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="397*"/>
                <RowDefinition Height="173*"/>
            </Grid.RowDefinitions>
            <ProgressBar x:Name="PBarCustom" Width="958" Height="200"  Maximum="958"  Value="958" Foreground="#FFE6E61F" Margin="17,185,17,11.932" ValueChanged="PBarCustom_ValueChanged">
                <ProgressBar.Background>
                    <ImageBrush ImageSource="http://res.freestockphotos.biz/pictures/16/16242-illustration-of-a-green-snake-pv.png"/>
                </ProgressBar.Background>
                <ProgressBar.Template>
                    <ControlTemplate>
                        <Grid Background="{TemplateBinding Background}">
                            <Rectangle x:Name="Thumb" HorizontalAlignment="Left" Fill="#FFC5EA1F" Stroke="#FF0DB442" Width="{TemplateBinding Width}" />
    
                            <Ellipse Fill="#FF7DEEDE" Height="124"  Stroke="#FF0DB442" Width="150" VerticalAlignment="Center" HorizontalAlignment="Center" Opacity="0.3"/>
                            <Label x:Name="tbStatus" VerticalContentAlignment="Center" HorizontalContentAlignment="Center" FontWeight="Bold" FontSize="75" Foreground="#FF21BD76" Content="0"  />
    
                        </Grid>
                    </ControlTemplate>
                </ProgressBar.Template>
    
            </ProgressBar>
            <Button x:Name="BtnLoadSnake" Content="Load Snake" HorizontalAlignment="Left" Margin="462,14.068,0,0" VerticalAlignment="Top" Width="75" Click="BtnLoadSnake_Click" Grid.Row="1"/>
        </Grid>
    </Window>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    
    namespace WpfControlTemplates._32794074
    {
        /// <summary>
        /// Interaction logic for Win32794074.xaml
        /// </summary>
        public partial class Win32794074 : Window
        {
            public Win32794074()
            {
                InitializeComponent();
                
            }
    
            DispatcherTimer timer;
            private void BtnLoadSnake_Click(object sender, RoutedEventArgs e)
            {
                BtnLoadSnake.IsEnabled = false;
                PBarCustom.Value = PBarCustom.Maximum;
                Rectangle thumb = (Rectangle)PBarCustom.Template.FindName("Thumb", PBarCustom);
                thumb.Width = PBarCustom.Value;
    
                Label status = (Label)PBarCustom.Template.FindName("tbStatus", PBarCustom);
                status.Content = ((int)(100 - ((100 * PBarCustom.Value) / PBarCustom.Maximum))).ToString();
    
                Dispatcher disp = PBarCustom.Dispatcher;
    
                EventHandler pBarCallbackHandler = new EventHandler(pBarCallback);
    
                timer = new DispatcherTimer(TimeSpan.FromSeconds(0.5), DispatcherPriority.Normal, pBarCallback, disp);            
                
            }
    
            private void pBarCallback(object sender, EventArgs e)
            {
                PBarCustom.Value -= 13;
                Rectangle thumb = (Rectangle)PBarCustom.Template.FindName("Thumb", PBarCustom);
                thumb.Width = PBarCustom.Value;
    
                Label status = (Label)PBarCustom.Template.FindName("tbStatus", PBarCustom);
                status.Content = ((int)(100 - ((100 * PBarCustom.Value) / PBarCustom.Maximum))).ToString();
    
                if (PBarCustom.Value == 0)
                    timer.Stop();
            }
    
            private void PBarCustom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            {            
                if(e.NewValue == 0)
                    BtnLoadSnake.IsEnabled = true;
            }
        }
    }
