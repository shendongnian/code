        public static List <MultipleTextBoxControl.TextBoxData> MasterDataList = new List<MultipleTextBoxControl.TextBoxData>();
		public void Register(MultipleTextBoxControl.TextBoxData data)
		{
			MasterDataList.Add(data);
		}
        private void CreateNewControl_Click(object sender, RoutedEventArgs e)
        {
			MultipleTextBoxControl newUserControl = new MultipleTextBoxControl(MultipleTextBoxControlID, this);
			UserControlContainer.Children.Add(newUserControl);
        }
