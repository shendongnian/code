    using System;
    using System.Windows;
    using System.Windows.Input;
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void LetterBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsClicked = !IsClicked;
    
            if (IsClicked)
            {
                LetterBlock.CaptureMouse();
            }
            else
            {
                LetterBlock.ReleaseMouseCapture();
            }
        }
    
        private void LetterBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsClicked)
                return;
            Point position = Mouse.GetPosition(this);    
            Thickness nMargin = new Thickness(position.X, position.Y, 0, 0);
            LetterBlock.Margin = nMargin;
    
            //InvalidateVisual();
        }
    
        public bool IsClicked { get; set; }
    }
