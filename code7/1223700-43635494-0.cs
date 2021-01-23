    ////////////////////////
    // REGEXTEXTBOX CLASS //
    ////////////////////////
	using System.Windows.Controls; // Textbox
	using System.Windows.Input;
	using System.Text.RegularExpressions; // Regex
	namespace MyNamespace
	{
	    public class RegexTextBox : TextBox
	    {
		    private Regex _regex = null;
		    public Regex Regex
		    {
		        get { return _regex; }
		        set { _regex = value; }
		    }
	        ///////////////////////////////////////////////////////////////////////
		    // MEMBERS
		    protected override void OnPreviewTextInput(TextCompositionEventArgs e)
		    {
		        var prefix = "OnPreviewTextInput() - ";
		        logger.Debug(prefix + "Entering");
		        string currentText = this.Text;
		        string candidateText = currentText + e.Text;
		        // If we have a set regex, and the current text fails,
		        // mark as handled so the text is not processed.
		        if (_regex != null && !_regex.IsMatch(candidateText))
		        {
			        e.Handled = true;
		        }		    
		        base.OnPreviewTextInput(e);
		    }
	    } // end of class RegexTextbox
	} // end of MyNamespace
    /////////////////////
    // MAINWINDOW.XAML //
    /////////////////////
    //(Window class needs to know your namespace so it needs xmlns:myNamespace="clr-namespace:MyNamespace")
  
	<myNamespace:RegexTextBox 
	 x:Name="textboxPayToAmount" 
	 Text="{Binding PayToAmount}">
	</myNamespace:RegexTextBox> 
  
  
    ////////////////////////
    // MAINWINDOW.XAML.CS //
    ////////////////////////
	namespace MyNamespace
	{
	    /// <summary>
	    /// Interaction logic for MainWindow.xaml
	    /// </summary>
	    public partial class MainWindow : Window
	    {
		    public MainWindow()
		    {
		        InitializeComponent();
    		    textboxPayToAmount.Regex = 
			        new System.Text.RegularExpressions.Regex(@"^\d*(\.\d{0,8})?$");
		    }
	    }
	}
