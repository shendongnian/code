	using System;
	using System.Collections.Generic;
	using System.Windows;
	using System.Windows.Controls;
	namespace SplashScreenDemo
	{
		public partial class MainWindow : Window
		{
			Dictionary<Type, Action<Control, String>> SetContent = new Dictionary<Type, Action<Control, String>> 
			{
				{ typeof(TextBox), (control, content) =>  (control as TextBox).Text = content},
				{ typeof(Label), (control, content) =>  (control as Label).Content = content}
			};
			public MainWindow()
			{
				InitializeComponent();
				Control control = getObjectClass("textbox");
				SetContent[control.GetType()](control, "This is a textbox");
				Control control2 = getObjectClass("label");
				SetContent[control2.GetType()](control2, "This is a label");
				StackPanelObj.Children.Add(control);
				StackPanelObj.Children.Add(control2);
			}
			public Control getObjectClass(string type)
			{
				switch (type)
				{
					case "textbox":
						return new TextBox();
					case "label":
						return new Label();
					default:
						return null;
				}
			}
		}
	}
