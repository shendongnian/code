    public static void SetRequestedTheme(ApplicationTheme theme, bool UseBackgroundChecked)
		{
			WindowWrapper.Current().Dispatcher.Dispatch(() =>
			{
				(Window.Current.Content as FrameworkElement).RequestedTheme = theme.ToElementTheme();
				ParseStyleforThemes(theme);
				HamburgerMenu.NavButtonCheckedForeground = NavButtonCheckedForegroundBrush;
				HamburgerMenu.NavButtonCheckedBackground = (UseBackgroundChecked) ?
					NavButtonCheckedBackgroundBrush : NavButtonBackgroundBrush;
				HamburgerMenu.NavButtonCheckedIndicatorBrush = (UseBackgroundChecked) ?
					Colors.Transparent.ToSolidColorBrush() : NavButtonCheckedIndicatorBrush;
				HamburgerMenu.SecondarySeparator = SecondarySeparatorBrush;
				List<HamburgerButtonInfo> NavButtons = HamburgerMenu.PrimaryButtons.ToList();
				NavButtons.InsertRange(NavButtons.Count, HamburgerMenu.SecondaryButtons.ToList());
				List<HamburgerMenu.InfoElement> LoadedNavButtons = new List<HamburgerMenu.InfoElement>();
				foreach (var hbi in NavButtons)
				{
					StackPanel sp = hbi.Content as StackPanel;
					if (hbi.ButtonType == HamburgerButtonInfo.ButtonTypes.Literal) continue;
					ToggleButton tBtn = sp.Parent as ToggleButton;
					Button btn = sp.Parent as Button;
					if (tBtn != null)
					{
						var button = new HamburgerMenu.InfoElement(tBtn);
						LoadedNavButtons.Add(button);
					}
					else if (btn != null)
					{
						var button = new HamburgerMenu.InfoElement(btn);
						LoadedNavButtons.Add(button);
						continue;
					}
					else
					{
						continue;
					}
					Rectangle indicator = tBtn.FirstChild<Rectangle>();
					indicator.Visibility = ((!hbi.IsChecked ?? false)) ? Visibility.Collapsed : Visibility.Visible;
					if (!hbi.IsChecked ?? false) continue;
					ContentPresenter cp = tBtn.FirstAncestor<ContentPresenter>();
					cp.Background = NavButtonCheckedBackgroundBrush;
					cp.Foreground = NavButtonCheckedForegroundBrush;
				}
				LoadedNavButtons.ForEach(x => x.RefreshVisualState());
			});
		}
