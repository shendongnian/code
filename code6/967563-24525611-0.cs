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
	namespace AdornerTest {
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window {
			public MainWindow() {
				InitializeComponent();
			}
			private void button_Click(object sender, RoutedEventArgs e) {
				StackPanel overlayPanel = new StackPanel() {
					Background = new SolidColorBrush(Color.FromArgb(0x99, 0, 0, 0xFF)),
				};
				// example content 1
				Rectangle overlayChild1 = new Rectangle() {
					Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF)),
					Margin = new Thickness(10),
					Height = 50,
				};
				overlayPanel.Children.Add(overlayChild1);
				// example content 2
				Button overlayChild2 = new Button();
				overlayChild2.Content = "asdasd";
				overlayChild2.Margin = new Thickness(10);
				overlayPanel.Children.Add(overlayChild2);
				OverlayAdorner adorner = new OverlayAdorner(mainGrid) {
					Content = overlayPanel,
				};
				AdornerLayer.GetAdornerLayer(mainGrid).Add(adorner);
			}
		}
		class OverlayAdorner : Adorner {
			private FrameworkElement _content;
			public OverlayAdorner(UIElement adornedElement)
				: base(adornedElement) {
			}
			protected override int VisualChildrenCount {
				get {
					return _content == null ? 0 : 1;
				}
			}
			protected override Visual GetVisualChild(int index) {
				if (index != 0) throw new ArgumentOutOfRangeException();
				return _content;
			}
			public FrameworkElement Content {
				get { return _content; }
				set {
					if (_content != null) {
						RemoveVisualChild(_content);
					}
					_content = value;
					if (_content != null) {
						AddVisualChild(_content);
					}
				}
			}
			protected override Size ArrangeOverride(Size finalSize) {
				_content.Arrange(new Rect(new Point(0, 0), finalSize));
				return base.ArrangeOverride(finalSize);
			}
		}
	}
