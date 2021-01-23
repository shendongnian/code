    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    
    namespace WpfApplication1
    {
    	[TemplatePart(Name = "tmpToolBar", Type = typeof(ToolBar))]
    	[TemplatePart(Name = "tmpStatusBar", Type = typeof(StatusBar))]
    	public class MyWindow : Window
    	{
    		protected ToolBar myToolBar;
    		protected StatusBar myStatusBar;
    
    		public MyWindow() : base()
    		{
    			// NOW, look for the resource of "MyWindowStyle" within the dictionary
    			var tryStyle = FindResource("MyWindowStyle") as Style;
    			// if a valid find and it IS of type Style, set the style of 
    			// the form to this pre-defined format and all it's content
    			if (tryStyle is Style)
    				Style = tryStyle;
    		}
    
    		// the actual template is not applied until some time after initialization.
    		// at that point, we can then look to grab object references to the controls
    		// you have need to "hook up" to.
    		public override void OnApplyTemplate()
    		{
    			// first allow default to happen
    			base.OnApplyTemplate();
    
    			// while we get the style loaded, we can now look at the expected template "parts"
    			// as declared at the top of this class.  Specifically looking for the TEMPLATE
    			// declaration by the name "tmpToolBar" and "tmpStatusBar" respectively.
    
    			// get object pointer to the template as defined in the style template
    			// Now, store those object references into YOUR Window object reference of Toolbar
    			var myToolBar = Template.FindName("tmpToolBar", this) as ToolBar;
    			if (myToolBar != null)
    				// if you wanted to add your own hooks to the toolbar control
    				// that is declared in the template
    				myToolBar.PreviewMouseDoubleClick += myToolBar_PreviewMouseDoubleClick;
    
    			// get object pointer to the template as defined in the style template
    			var myStatusBar = Template.FindName("tmpStatusBar", this) as StatusBar;
    			if (myStatusBar != null)
    				myStatusBar.MouseDoubleClick += myStatusBar_MouseDoubleClick;
    
    			// Now, you can do whatever else you need with these controls downstream to the 
    			// rest of your derived window controls
    		}
    
    		void myToolBar_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    		{
    			// in case you wanted to do something based on PreviewMouseDoubleClick of the toolbar
    			MessageBox.Show("ToolBar: Current Window Class: " + this.ToString());
    		}
    
    		void myStatusBar_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    		{
    			// in case something for MouseDoubleClick on the StatusBar
    			MessageBox.Show("StatusBar: Current Window Class: " + this.ToString());
    		}
    	}
    }
