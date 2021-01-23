    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication5
    {
        public enum SlideInFromDirection
        {
            Left = 0,
            Top = 1,
            Right = 2,
            Bottom = 3,
        }
    
        [TemplatePart(Name = "SlideContainerClosed", Type = typeof(ContentPresenter)),
        TemplatePart(Name = "SlideContainerExpanded", Type = typeof(ContentPresenter)),
        TemplateVisualState(Name = "Closed", GroupName = "ViewStates"),
        TemplateVisualState(Name = "Expanded", GroupName = "ViewStates")]
        public class SlideGrid : System.Windows.Controls.Control
        {
            public static readonly DependencyProperty ClosedStateProperty = DependencyProperty.Register("ClosedState", typeof(object), typeof(SlideGrid), null);
            public static readonly DependencyProperty ExpandedStateProperty = DependencyProperty.Register("ExpandedState", typeof(object), typeof(SlideGrid), null);
    
            public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(SlideGrid), null);
    
    
            public SlideInFromDirection SlideInFrom
            {
                get { return (SlideInFromDirection)GetValue(SlideInFromProperty); }
                set { SetValue(SlideInFromProperty, value); }
            }
            public static readonly DependencyProperty SlideInFromProperty =
                DependencyProperty.Register("SlideInFrom", typeof(SlideInFromDirection), typeof(SlideGrid), new PropertyMetadata(SlideInFromDirection.Left, slideInFromPropertyChangedCallback));
    
            private static void slideInFromPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                SlideGrid sg = d as SlideGrid;
                if (sg != null && e.NewValue is SlideInFromDirection)
                {
                    if (sg.VSExpandedX == null || sg.VSExpandedY == null)
                        return;
                    SlideInFromDirection sd = (SlideInFromDirection)e.NewValue;
                    switch (sd)
                    {
                        case SlideInFromDirection.Left:
                            sg.VSExpandedX.From = -300.0;
                            sg.VSExpandedY.From = 0.0;
                            break;
                        case SlideInFromDirection.Right:
                            sg.VSExpandedX.From = 300.0;
                            sg.VSExpandedY.From = 0.0;
                            break;
                        case SlideInFromDirection.Top:
                            sg.VSExpandedX.From = 0.0;
                            sg.VSExpandedY.From = -300.0;
                            break;
                        case SlideInFromDirection.Bottom:
                            sg.VSExpandedX.From = 0.0;
                            sg.VSExpandedY.From = 300.0;
                            break;
                    }
                }
            }
            private System.Windows.Media.Animation.DoubleAnimation VSExpandedX;
            private System.Windows.Media.Animation.DoubleAnimation VSExpandedY;
    
            static SlideGrid()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(SlideGrid), new FrameworkPropertyMetadata(typeof(SlideGrid)));
            }
    
            public object ClosedState
            {
                get
                {
                    return base.GetValue(ClosedStateProperty);
                }
                set
                {
                    base.SetValue(ClosedStateProperty, value);
                }
            }
    
            public object ExpandedState
            {
                get
                {
                    return base.GetValue(ExpandedStateProperty);
                }
                set
                {
                    base.SetValue(ExpandedStateProperty, value);
                }
            }
    
            public bool IsExpanded
            {
                get
                {
                    return (bool)base.GetValue(IsExpandedProperty);
                }
                set
                {
                    base.SetValue(IsExpandedProperty, value);
                    ChangeVisualState(true);
                }
            }
    
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                ContentPresenter slideContainerClosed = base.GetTemplateChild("ClosedState") as ContentPresenter;
                if (slideContainerClosed != null) slideContainerClosed.MouseEnter += slideContainerClosed_GotMouseCapture;
    
                ContentPresenter slideContainerExpanded = base.GetTemplateChild("ExpandedState") as ContentPresenter;
                if (slideContainerExpanded != null) slideContainerExpanded.MouseLeave += slideContainerExpanded_LostMouseCapture;
    
                this.VSExpandedX = base.GetTemplateChild("VSExpandedX") as System.Windows.Media.Animation.DoubleAnimation;
                this.VSExpandedY = base.GetTemplateChild("VSExpandedY") as System.Windows.Media.Animation.DoubleAnimation;
                slideInFromPropertyChangedCallback(this, new DependencyPropertyChangedEventArgs(SlideInFromProperty, this.SlideInFrom, this.SlideInFrom));
    
                this.ChangeVisualState(false);
            }
    
            private void slideContainerClosed_GotMouseCapture(object sender, MouseEventArgs e)
            {
                this.IsExpanded = true;
            }
    
            private void slideContainerExpanded_LostMouseCapture(object sender, MouseEventArgs e)
            {
                this.IsExpanded = false;
            }
    
            private void ChangeVisualState(bool useTransitions)
            {
                if (!this.IsExpanded)
                {
                    VisualStateManager.GoToState(this, "Closed", useTransitions);
                }
                else
                {
                    VisualStateManager.GoToState(this, "Expanded", useTransitions);
                }
    
                UIElement closed = ClosedState as UIElement;
                if (closed != null)
                {
                    if (IsExpanded)
                    {
                        closed.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        closed.Visibility = Visibility.Visible;
                    }
                }
                UIElement expanded = ExpandedState as UIElement;
                if (expanded != null)
                {
                    if (IsExpanded)
                    {
                        expanded.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        expanded.Visibility = Visibility.Hidden;
                    }
                }
            }
        }
    }
