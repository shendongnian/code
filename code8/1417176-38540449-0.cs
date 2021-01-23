    public class ManipulationImage
        : Image
    {
        /// <summary>
        /// The <see cref="DependencyProperty" /> that represents the property value in the <see cref="DependencyObject" />
        /// and enables binding to a command.
        /// </summary>
        public static readonly DependencyProperty ManipulationCommandProperty = DependencyProperty.Register(
            nameof(ManipulationCommand),
            typeof(ICommand),
            typeof(ManipulationImage),
            new PropertyMetadata(default(ICommand)));
    
        /// <summary>
        /// Gets or sets the value of the <see cref="ManipulationCommandProperty" /> in the <see cref="ManipulationImage" />.
        /// </summary>
        public ICommand ManipulationCommand
        {
            get { return (ICommand)this.GetValue(ManipulationCommandProperty); }
            set { this.SetValue(ManipulationCommandProperty, value); }
        }
    }
