	new Table(
		new TableProperties(
			new TableStyle() { Val = "TableGrid" },
			new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto }),
		new TableGrid(
			new GridColumn() { Width = "2000" },
			new GridColumn() { Width = "2000" },
			new GridColumn() { Width = "2000" },
			new GridColumn() { Width = "2000" }),
		new TableRow(
			new TableRowProperties(
                new CantSplit()),
            new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 1")))),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 1")))),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 1")))),
			new TableCell(
				new Paragraph(
					new ParagraphProperties(
						new KeepNext(),
						new KeepLines()),
					new Run(
					new Text("Table Row 1"))))),
	   new TableRow(
			new TableRowProperties(
                new CantSplit()),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 2")))),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 2")))),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 2")))),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 2"))))),
	  new TableRow(
			new TableRowProperties(
                new CantSplit()),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 3")))),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 3")))),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 3")))),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 3"))))),
	 new TableRow(
			new TableRowProperties(
                new CantSplit()),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 4")))),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 4")))),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 4")))),
			new TableCell(
				new Paragraph(
					new Run(
					new Text("Table Row 4"))))))));
