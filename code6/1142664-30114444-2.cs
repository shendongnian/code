	private void saveToolStripMenuItem_Click(object sender,System.EventArgs e)
	{
		var _Bitmap = new Bitmap(bitmap);
		//when we quit here we don't need this anymore; declaring it here helps with memory management
		if(_Bitmap == null)
			return;
		
		if(string.IsNullorEmpty(fileName)||string.IsNullorWhiteSpace(fileName)
		{
			Filter = @"Image files (*.bmp)|*.bmp|All files (*.*)|*.*",
			FileName = "MyPicture.bmp"
		}
		else
		{
			_Bitmap.Save(fileName,ImageFormat.Bmp);
		}
	}
