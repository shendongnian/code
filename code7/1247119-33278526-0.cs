     try
	{
    System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
			System.IO.Stream myStream = myAssembly.GetManifestResourceStream("QBoard");
			img = ReadFully (myStream);
		}
		catch
		{
			print("Error accessing resources!");
		}
		Texture2D myTexture = new Texture2D(2, 2);
		myTexture.LoadImage(img);
		GUI.Box (new Rect (dWidth/2-50, dHeight/2-50,200,50),new GUIContent(myObject.text,myTexture));
