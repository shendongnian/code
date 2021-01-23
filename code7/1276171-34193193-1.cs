    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;
    using System.Windows.Media;
    using System.Windows.Threading;
    using System.Windows.Input;
    using Microsoft.Expression.Interactivity;
    namespace MyProject.Behaviors
    {
        public class BringSelectionToViewBehavior : Behavior<ItemsControl>
        {
            Queue<Point> velocityPoints = new Queue<Point>(4);
            Point PreviousPoint { get; set; }
            DispatcherTimer valocityTimer = new DispatcherTimer();
            public object SelectedItem
            {
                get { return GetValue(SelectedItemProperty); }
                set { SetValue(SelectedItemProperty, value); }
            }
            // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SelectedItemProperty =
                DependencyProperty.Register("SelectedItem", typeof(object), typeof(BringSelectionToViewBehavior), new UIPropertyMetadata(null, OnSelectedItemChanged));
            protected override void OnAttached()
            {
                base.OnAttached();
                AssociatedObject.AddHandler(ItemsControl.SizeChangedEvent, (SizeChangedEventHandler)OnWidthChanged);
                AssociatedObject.LayoutUpdated += new EventHandler(AssociatedObject_LayoutUpdated);
                AssociatedObject.ReleaseMouseCapture();
                valocityTimer.Interval = TimeSpan.FromMilliseconds(20);
                valocityTimer.Tick += valocityTimer_Tick;
            }
            ItemsPresenter itemsPresenter;
            void AssociatedObject_LayoutUpdated(object sender, EventArgs e)
            {
                if (itemsPresenter == null)
                {
                    itemsPresenter = AssociatedObject.FindChildrenByType<ItemsPresenter>().ToList().First();
                    AssociatedObject.MouseMove += AssociatedObject_MouseMove;
                    itemsPresenter.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(ItemPresenter_MouseLeftButtonDown), false);
                    itemsPresenter.AddHandler(UIElement.MouseLeftButtonUpEvent, new MouseButtonEventHandler(ItemPresenter_MouseLeftButtonUp), true);
                }
            }
            public void OnWidthChanged(object s, SizeChangedEventArgs e)
            {
                Dispatcher.BeginInvoke((Action<ItemsControl, object>)QueueAnimation, DispatcherPriority.Render, new[] { AssociatedObject, SelectedItem });
            }
            private void QueueAnimation(ItemsControl control, object item)
            {
                BringItemToView(item);
            }
            public static void OnSelectedItemChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
            {
                if (e.NewValue == null)
                    return;
                BringSelectionToViewBehavior behavior = s as BringSelectionToViewBehavior;
                if (!behavior.valocityOverride.HasValue)
                    behavior.BringItemToView(e.NewValue);
            }
            private void BringItemToView(object item, EasingMode easeMode = EasingMode.EaseInOut)
            {
                if (item == null || AssociatedObject == null)
                    return;
                FrameworkElement element = AssociatedObject.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                BringElementToView(element, easeMode);
            }
            private void BringElementToView(FrameworkElement element, EasingMode easeMode)
            {
                if (element == null)
                    return;
                ScrollViewer scrollViewer = element.FindAncestorByType<ScrollViewer>();
                if (scrollViewer != null)
                {
                    Point relativePoint = element.TransformToAncestor(scrollViewer).Transform(new Point(0, 0));
                    ScrollToPosition(scrollViewer, relativePoint.X, relativePoint.Y, easeMode);
                }
                else
                {
                    element.BringIntoView();
                }
            }
            private void ScrollToPosition(ScrollViewer viewer, double x, double y, EasingMode easeMode)
            {
                Storyboard sb = new Storyboard();
                if (y != 0)
                {
                    DoubleAnimation vertAnim = new DoubleAnimation();
                    //if (applyEase)
                    vertAnim.EasingFunction = new CubicEase() { EasingMode = easeMode };
                    vertAnim.From = viewer.VerticalOffset;
                    vertAnim.By = y;
                    vertAnim.Duration = GetAnimationDuration(y);
                    sb.Children.Add(vertAnim);
                    Storyboard.SetTarget(vertAnim, viewer);
                    Storyboard.SetTargetProperty(vertAnim, new PropertyPath(BringSelectionToViewBehavior.VerticalOffsetProperty));
                }
                if (x != 0)
                {
                    DoubleAnimation horzAnim = new DoubleAnimation();
                    horzAnim.From = viewer.HorizontalOffset;
                    horzAnim.By = x;
                    horzAnim.Duration = GetAnimationDuration(x);
                    horzAnim.EasingFunction = new CubicEase() { EasingMode = easeMode };
                    sb.Children.Add(horzAnim);
                    Storyboard.SetTarget(horzAnim, viewer);
                    Storyboard.SetTargetProperty(horzAnim, new PropertyPath(BringSelectionToViewBehavior.HorizontalOffsetProperty));
                }
                //overrideDuretion = false;
                sb.Completed += new EventHandler(sb_Completed);
                sb.Begin();
            }
            void sb_Completed(object sender, EventArgs e)
            {
                ((sender as ClockGroup).Timeline as Storyboard).Remove();
                valocityOverride = null;
            }
            double? valocityOverride;
            private Duration GetAnimationDuration(double distanceToTravel)
            {
                double animTime = Math.Abs(distanceToTravel) * .7;
                if (valocityOverride.HasValue && valocityOverride > 50)
                {
                    animTime = Math.Abs(distanceToTravel) * (valocityOverride.Value / 1000);
                }
                if (animTime > 1500)
                    animTime = 1500;
                if (animTime < 250)
                    animTime = 250;
                return new Duration(TimeSpan.FromMilliseconds(animTime));
            }
            public static double GetVerticalOffset(DependencyObject obj)
            {
                return (double)obj.GetValue(VerticalOffsetProperty);
            }
            public static void SetVerticalOffset(DependencyObject obj, double value)
            {
                obj.SetValue(VerticalOffsetProperty, value);
            }
            // Using a DependencyProperty as the backing store for VerticalOffset.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty VerticalOffsetProperty =
                DependencyProperty.RegisterAttached("VerticalOffset", typeof(double), typeof(BringSelectionToViewBehavior), new PropertyMetadata(new PropertyChangedCallback(OnVerticalChanged)));
            public static double GetHorizontalOffset(DependencyObject obj)
            {
                return (double)obj.GetValue(HorizontalOffsetProperty);
            }
            public static void SetHorizontalOffset(DependencyObject obj, double value)
            {
                obj.SetValue(HorizontalOffsetProperty, value);
            }
            // Using a DependencyProperty as the backing store for HorizontalOffset.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty HorizontalOffsetProperty =
                DependencyProperty.RegisterAttached("HorizontalOffset", typeof(double), typeof(BringSelectionToViewBehavior), new PropertyMetadata(new PropertyChangedCallback(OnHorizontalChanged)));
            private static void OnVerticalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ScrollViewer viewer = d as ScrollViewer;
                viewer.ScrollToVerticalOffset((double)e.NewValue);
            }
            private static void OnHorizontalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ScrollViewer viewer = d as ScrollViewer;
                viewer.ScrollToHorizontalOffset((double)e.NewValue);
            }
            void valocityTimer_Tick(object sender, EventArgs e)
            {
                Point currentPoint = Mouse.GetPosition(AssociatedObject);
                velocityPoints.Enqueue(currentPoint);
                if (velocityPoints.Count > 4)
                    velocityPoints.Dequeue();
            }
            private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
            {
                if (itemsPresenter.IsMouseCaptured)
                {
                    Point CurrentPoint = e.GetPosition(AssociatedObject);
                    Vector offset = PreviousPoint - CurrentPoint;
                    PreviousPoint = CurrentPoint;
                    if (offset.X != 0)
                    {
                        Viewer.ScrollToHorizontalOffset(Viewer.HorizontalOffset + offset.X);
                    }
                }
            }
            public ScrollViewer Viewer { get; set; }
            /// <summary>
            /// Handles the MouseLeftButtonDown event of the ItemPresenter control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
            private void ItemPresenter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                //Viewer.ApplyAnimationClock(BringSelectionToViewBehavior.HorizontalOffsetProperty, null);
                Border bd = (e.OriginalSource as FrameworkElement).FindAncestorByType<Border>();
                if (bd == null || (bd != null && bd.Name != "GripBarElement"))
                {
                    Viewer = AssociatedObject.FindChildrenByType<ScrollViewer>().ToList().First();
                    PreviousPoint = e.GetPosition(AssociatedObject);
                    itemsPresenter.CaptureMouse();
                    velocityPoints.Clear();
                    valocityTimer.Start();
                }
            }
            private double CalculateMouseSpeed()
            {
                if (velocityPoints.Count > 1)
                {
                    Point first = velocityPoints.Dequeue();
                    return velocityPoints.Aggregate<Point, Point, double>(first, (s, pt) => new Point(s.X, pt.X), pt => pt.X - pt.Y);
                }
                return 0;
            }
            /// <summary>
            /// Handles the MouseLeftButtonUp event of the ItemPresenter control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
            private void ItemPresenter_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                if (itemsPresenter.IsMouseCaptured)
                {
                    if (Viewer == null)
                        return;
                    valocityTimer.Stop();
                    itemsPresenter.ReleaseMouseCapture();
                    double MouseSpeed = CalculateMouseSpeed() / 3;
                    double newtotal = 5 * MouseSpeed;
                    double newOffset = Viewer.HorizontalOffset + newtotal;
                    double maxOffset = itemsPresenter.ActualWidth - (itemsPresenter.ActualWidth / AssociatedObject.Items.Count);
                    if (newOffset < 0)
                    {
                        newtotal += 0 - newOffset;
                    }
                    else if (newOffset > maxOffset)
                    {
                        newtotal -= newOffset - maxOffset;
                    }
                    newOffset = Viewer.HorizontalOffset + newtotal;
                    int newIndex = (int)System.Math.Round(newOffset / (itemsPresenter.ActualWidth / AssociatedObject.Items.Count));
                    object objToSet = AssociatedObject.ItemsSource.OfType<object>().ElementAt(newIndex);
                    if (objToSet != null)
                    {
                        valocityOverride = MouseSpeed;
                        if (!object.Equals(SelectedItem, objToSet))
                            SelectedItem = objToSet;
                        BringItemToView(objToSet, EasingMode.EaseOut);
                    }
                }
            }
        }
    }
