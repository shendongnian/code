    var doc = new XpsDocument( "out.xps", FileAccess.Write );
			var xpsdw = XpsDocument.CreateXpsDocumentWriter( doc );
			
			FixedDocument document = new FixedDocument();
			FixedPage page = new FixedPage();
			FixedPage.SetLeft( yourCanvas, 0 );
			FixedPage.SetTop( yourCanvas, 0 );
			
			page.Width = pageWidth;
			page.Height = pageHeight;
			page.Children.Add( yourCanvas );
			page.Measure( new Size( pageWidth, pageHeight ) );
			page.Arrange( new Rect( 0, 0, pageWidth, pageHeight ) );
			page.UpdateLayout();
			
			PageContent page_content = new PageContent();
			( (IAddChild)page_content ).AddChild( page );
			
			document.Pages.Add( page_content );
			xpsdw.Write( document );
			doc.Close();
