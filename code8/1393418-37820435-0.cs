    Globals.YourAddin.Application.DocumentOpen += doc =>
			{
				if (doc.Name.EndsWith(".customTemplateExtension"))
				{
					Globals.YourAddin.Application.ActiveWindow.View.ReadingLayout = false;
					Globals.YourAddin.Application.ActiveWindow.View.Type = WdViewType.wdPrintView;
				}
			};
    Globals.YourAddin.Application.DocumentBeforeClose += (Document doc, ref bool cancel) =>
			{
				if (doc.Name.EndsWith(".customPreviewExtension"))
				{
					    Globals.YourAddin.Application.ActiveWindow.View.ReadingLayout = false;
				}
			};
