	using System;
	using Xamarin.Forms;
	namespace CustomEntrySample
	{
		public class EntryWithTopPadding : Entry
		{
		}
		public class App : Application
		{
			public App()
			{
				var normalEntry = new Entry
				{
					Text = "This Entry Has Normal Padding",
					BackgroundColor = Color.Lime
				};
				var paddedEntry = new EntryWithTopPadding
				{
					Text = "This Entry Has Extra Top Padding",
					BackgroundColor = Color.Aqua
				};
				var mainLayout = new RelativeLayout();
				mainLayout.Children.Add(
					normalEntry,
					Constraint.Constant(0),
					Constraint.RelativeToParent(parent => parent.Y + 10),
					Constraint.RelativeToParent(parent => parent.Width)
				);
				mainLayout.Children.Add(
					paddedEntry,
					Constraint.Constant(0),
					Constraint.RelativeToView(normalEntry, (parent, view) => view.Y + view.Height + 10),
					Constraint.RelativeToParent(parent => parent.Width),
					Constraint.Constant(50)
				);
				MainPage = new NavigationPage(
					new ContentPage
					{
						Title = "Title",
						Content = mainLayout,
						Padding = new Thickness(10, 0, 10, 0)
					}
				);
			}
		}
	}
