	public class RankBoard : BindableBase
	{
		private Color _buttonColor;
		public Color ButtonColor 
		{
			get
			{
				return _buttonColor;
			}
			set
			{
				_buttonColor = value;
				RaisePropertyChanged("ButtonColor");
			}
		}
		
		public void RefreshButtonColor()
		{
			foreach (var x in StudentList.Where(i=>i.StudentNo==System.Convert.ToInt32(b.Content)))
			{
				if ((x.State.ToString()=="Pass"))
				{
					ButtonColor = Colors.Green;
				}
				else
				{
					ButtonColor = Colors.Red;
				}
			}
		}
	}
