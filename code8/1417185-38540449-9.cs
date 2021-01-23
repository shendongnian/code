    using System;
    using System.Windows.Input;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    
    public class ManipulationContentControl
        : ContentControl
    {
        public static readonly DependencyProperty ManipulationCommandProperty =
            DependencyProperty.Register(
                nameof(ManipulationCommand),
                typeof(ICommand),
                typeof(ManipulationContentControl),
                new PropertyMetadata(default(ICommand)));
        
        public ICommand ManipulationCommand
        {
            get { return (ICommand)this.GetValue(ManipulationCommandProperty); }
            set { this.SetValue(ManipulationCommandProperty, value); }
        }
    }
