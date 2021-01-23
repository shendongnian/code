	private void ComputeGrandTotal()
	{
		//Since there are values that need to be validated and converted to integers for use in two calculations...
		int smll, mdm, lg, xl;
		//Validate the inputs can be converted and set the appropriate variable values at the same time
		if (Int32.TryParse(txtSmall.Text, out smll) //using TryParse sets the integer variable values only if they can successfully be converted
			&& Int32.TryParse(txtMedium.Text, out mdm)
			&& Int32.TryParse(txtLarge.Text, out lg)
			&& Int32.TryParse(txtExtralarge.Text, out xl)
			)
		{
			int ttl = smll + mdm + lg + xl;
			double GrandTotal, TagsCollars;
			TagsCollars = ttl;
			GrandTotal = TagsCollars * .285 * 315;
			txtTags.Text = $"{TagsCollars:#,##0}"; //Resharper suggested simplification of String.Format("{0:#,##0}", TagsCollars)....I believe ReSharper
			txtCollars.Text = $"{TagsCollars:#,##0}";
			lblGrandtotal.Text = $"{(GrandTotal + TagsCollars + TagsCollars):#,###,##0}";
		}
	}
