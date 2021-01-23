    namespace stackQues
    {
    	class YourTextCell:TextCell
    	{
    		public YourTextCell() {
    			this.SetBinding (TextCell.TextProperty, "TextLabel");
    			this.SetBinding (TextCell.DetailProperty, "DetailTextLabel");
    		}
    	}
    }
