    using System.ComponentModel;
    namespace MyApplication.ViewModel
    {
        internal interface IFlyoutViewModel : INotifyPropertyChanged
        {
            string Header { get; }
            bool Visible { get; set; }
            Position Position { get; set; }
            bool IsModal { get; set; }
        }
        public enum Position
        {
            Top,
            Left,
            Right,
            Bottom
        }
    }
