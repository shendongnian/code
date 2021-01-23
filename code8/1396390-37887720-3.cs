		private void CreateTbx ()
		{
			if ( ( bool ) Session[ "shown" ] )
			{
				string s = Session[ "num" ].ToString();
				int num = Int32.Parse( s );
				for ( int i =0; i < num; i++ )
				{
					TextBox _text = new TextBox();
					_text.Visible = true;
					_text.ID = string.Format( "TbxInput{0}", i );
					PlaceHolder1.Controls.Add( _text );
				}
			}
		}
