			DataGridViewColumn[] dgCol = 
			{
			  new DataGridViewTextBoxColumn() 
			  {
				  HeaderText = "Conviction", 
				  SortMode = DataGridViewColumnSortMode.NotSortable,
				  Width = Convert.ToInt32(0.25f * grdConvictions.Width - 19)
			  },
			  new DataGridViewTextBoxColumn() 
			  {
				  HeaderText = "Points"    , 
				  SortMode = DataGridViewColumnSortMode.NotSortable,
				  Width = Convert.ToInt32(0.125f * grdConvictions.Width - 19)
			  },
			  new DataGridViewTextBoxColumn() 
			  {
				  HeaderText = "Date", 
				  SortMode = DataGridViewColumnSortMode.NotSortable,
				  Width = Convert.ToInt32(0.125f * grdConvictions.Width - 19),
			  },
			  new DataGridViewComboBoxColumn () 
			  {
				  HeaderText = "Galletas", 
				  Width = Convert.ToInt32(0.25 * grdConvictions.Width - 19),		  
				  DataPropertyName 	= "Galletas",
                  DataSource = new List<String>{"",
                                              "Maiz",
                                              "Pera",
                                              "Manzana",
                                              "Sandia",
                                              "Fresa",
                                              "Melon",
                                              "Melocoton",
                                              "Maracuya",
                                              "Cereza",
                                              "Frambuesa",
                                              "Mora",
                                              "Kiwi",
                                              "Anona",
                                              "Guayaba"
				                            },
				  SortMode = DataGridViewColumnSortMode.NotSortable,
				  MaxDropDownItems = 10,
				  
				  DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
				  ReadOnly = false
			  }
			};
