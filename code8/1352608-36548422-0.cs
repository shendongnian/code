    namespace stackQues
    {
    	public partial class Page : ContentPage
    	{
    		int count = 0;
    		List<TextCellItem> data = new MenuData ();
    		public Page()
    		{
    			InitializeComponent();
    			//this.ToolbarItems.Add(new ToolbarItem { Text = "Add" });
    
    		}
    
    		private void Add_Clicked(object sender, EventArgs e)
    		{
    			//cells.Add(new TextCell { Text = count.ToString(), Detail = DateTime.Now.ToString("dd/MM/yyyy --> hh:mm:ss") });
    		
    
    			data.Add (new TextCellItem {
    				TextLabel = count.ToString (),
    				DetailTextLabel = DateTime.Now.ToString ("dd/MM/yyyy --> hh:mm:ss")
    			});
    			count++;
    			list.ItemsSource = data;
    			list.ItemTemplate = new DataTemplate(typeof(YourTextCell));
    
    		}
    	}
    }
