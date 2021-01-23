	// initialize a new PrintDocument
	PDF print = new PDF();
	// set the font
	print.Font = new Font("Helvetica", (float)12, FontStyle.Regular, GraphicsUnit.Point);
	
	// change the color (can be used for shapes, etc once their draw methods are added to the PDF() class)
	print.ForeColor = Color.Red;
	
	// create a new page !!!!
	print.NewPage();
	
	// add some text
	print.DrawString( "Hello World !!" );
	
	// add some right aligned text
	print.DrawString( "Aligned Right", System.Windows.TextAlignment.Right );
	
	// add some centered text
	print.DrawString( "Aligned Right", System.Windows.TextAlignment.Center );
	// change line spacing ( percentage between 1% and 1000% )
	print.LineSpacing = 50; // 50% of drawstrings detected line height
	
	// add another page
	print.NewPage();
	// print a couple lines
	print.DrawString( "Hello World" );
	print.DrawString( "Hello World" );
	// change the color again and print another line
	ForeColor = Color.Yellow;
	print.DrawString( "Hello World" );
	// duplicate a page (clone page 1 as page 3 )
	print.NewPage();
	print.Pages[print.Pages -1] = print.GetPage(1);
	
	// go back to page 1 and print some more text at specified coordinates
	print.SetCurrentPage(1);
	print.X = 400;
	print.Y = 300;
	print.DrawString( "Drawn after 3rd page created" );
	
	// send the print job
	print.Print();
	
	// reprint
	print.Print();
	
	// show a preview of the 2nd page
	/*
		Image img = print.GetPage(1);
		pictureBox1.Height=(Int32)(print.CurrentPaperSize.Height*img.VerticalResolution);
		pictureBox1.Width = (Int32)(print.CurrentPaperSize.Width*img.HorizontalResolution);
		pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
		pictureBox1.Image = img;
	*/
