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
		
		public void RefreshButtonColor(int content)
		{
			foreach (var x in StudentList.Where(i=>i.StudentNo==content))
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
