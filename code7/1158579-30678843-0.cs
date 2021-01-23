    	private void tabControl_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e) {
			DXTabItem parentObject = DevExpress.Xpf.Core.Native.LayoutHelper.FindParentObject<DXTabItem>(e.OriginalSource as DependencyObject);
			
			// If the click happened over an empty area (i.e., no parent object was found), then toggle the admin button
			if (parentObject == null) {
				if (tabItem_Admin.Visibility == System.Windows.Visibility.Visible)
					tabItem_Admin.Visibility = System.Windows.Visibility.Collapsed;
				else
					tabItem_Admin.Visibility = System.Windows.Visibility.Visible;
			}
		}
