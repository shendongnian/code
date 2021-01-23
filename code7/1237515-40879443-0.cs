    using System;
	using Xamarin.Forms;
	namespace SwitchToggle
	{
		public class SwitchPage : ContentPage
		{
			public SwitchPage()
			{
				var mySwitch = new Switch
				{
					IsToggled = true
				};
				mySwitch.Toggled += HandleSwitchToggledByUser;
				var toggleButton = new Button
				{
					Text = "Toggle The Switch"
				};
				toggleButton.Clicked += (sender, e) =>
				{
					mySwitch.Toggled -= HandleSwitchToggledByUser;
					mySwitch.IsToggled = !mySwitch.IsToggled;
					mySwitch.Toggled += HandleSwitchToggledByUser;
				};
				var mainLayout = new RelativeLayout();
				Func<RelativeLayout, double> getSwitchWidth = (p) => mySwitch.Measure(mainLayout.Width, mainLayout.Height).Request.Width;
				Func<RelativeLayout, double> getToggleButtonWidth = (p) => toggleButton.Measure(mainLayout.Width, mainLayout.Height).Request.Width;
				mainLayout.Children.Add(mySwitch,
					Constraint.RelativeToParent((parent) => parent.Width / 2 - getSwitchWidth(parent) / 2),
					Constraint.RelativeToParent((parent) => parent.Height / 2 - mySwitch.Height / 2)
			   	);
				mainLayout.Children.Add(toggleButton,
					Constraint.RelativeToParent((parent) => parent.Width / 2 - getToggleButtonWidth(parent) / 2),
					Constraint.RelativeToView(mySwitch, (parent, view) => view.Y + view.Height + 10)
				);
				Content = mainLayout;
			}
			async void HandleSwitchToggledByUser(object sender, ToggledEventArgs e)
			{
				await DisplayAlert(
					"Switch Toggled By User",
					"",
					"OK"
				);
			}
		}
		public class App : Application
		{
			public App()
			{
				MainPage = new NavigationPage(new SwitchPage());
			}
		}
	}
