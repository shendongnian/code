    static void Main(string[] args)
	{
		// process register or unregister commands
		if (!ProcessCommand(args))
		{
            string action = args[0];
            MessageBox.Show(action);
            string fileName = args[1];
            if (action == "Copy")
            {
                // invoked from shell, process the selected file
                CopyGrayscaleImage(fileName);
            }
            else if (action == "List")
            {
                ListImage(fileName); 
            }
		}
	}
