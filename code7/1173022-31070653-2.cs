    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace CE.EthernetMessagesManager.Views
    {
    	public class CustomTextBox : TextBox
    	{
    		private int realCaretIndex = 0;
    		private bool triggeredByUser = false;
    		private bool isScrollingWithMouse = false;
    
    		public CustomTextBox()
    			: base()
    		{
    			this.PreviewMouseLeftButtonDown += CustomTextBox_PreviewMouseLeftButtonDown;
    			this.PreviewMouseLeftButtonUp += CustomTextBox_PreviewMouseLeftButtonUp;
    			this.PreviewMouseMove += CustomTextBox_PreviewMouseMove;
    			this.PreviewMouseWheel += CustomTextBox_PreviewMouseWheel;
    			this.TextChanged += CustomTextBox_TextChanged;
    			this.LostFocus += CustomTextBox_LostFocus;
    
    			this.AddHandler(ScrollViewer.ScrollChangedEvent, new RoutedEventHandler((X, S) =>
    			{
    				if ((S as ScrollChangedEventArgs).VerticalChange != 0 && triggeredByUser)
    				{
    					TextBox textBox = (X as TextBox);
    					int newLinePosition = 0;
    					newLinePosition = (int)(((S as ScrollChangedEventArgs).VerticalChange + textBox.ExtentHeight) / (textBox.FontSize + 2));
    
    					realCaretIndex += newLinePosition * ((S as ScrollChangedEventArgs).VerticalChange < 0 ? -1 : 1);
    					if (realCaretIndex < 0)
    						realCaretIndex = 0;
    
    					textBox.CaretIndex = realCaretIndex;
    					triggeredByUser = false;
    				}
    			}));
    		}
    
    		void CustomTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
    		{
    			e.Handled = true;
    		}
    
    		void CustomTextBox_TextChanged(object sender, TextChangedEventArgs e)
    		{
    			TextBox textBox = sender as TextBox;
    			textBox.CaretIndex = realCaretIndex;
    
    			var max = (textBox.ExtentHeight - textBox.ViewportHeight);
    			var offset = textBox.VerticalOffset;
    
    			if (max != 0 && max == offset)
    				this.Dispatcher.Invoke(new Action(() =>
    				{
    					textBox.ScrollToEnd();
    				}),
    					System.Windows.Threading.DispatcherPriority.Loaded);
    		}
    
    		void CustomTextBox_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
    		{
    			triggeredByUser = true;
    		}
    
    		void CustomTextBox_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    		{
    			if (isScrollingWithMouse)
    			{
    				TextBox textBox = sender as TextBox;
    				realCaretIndex = textBox.GetCharacterIndexFromPoint(Mouse.GetPosition(textBox), true);
    			}
    		}
    
    		void CustomTextBox_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    		{
    			isScrollingWithMouse = false;
    		}
    
    		void CustomTextBox_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    		{
    			TextBox textBox = sender as TextBox;
    			realCaretIndex = textBox.GetCharacterIndexFromPoint(Mouse.GetPosition(textBox), true);
    			triggeredByUser = true;
    			isScrollingWithMouse = true;
    		}
    	}
    }
