	public IQueryable<ViewMaterial> ViewIMaterial()
	{
		return _ctx.Materials.Take(20)
			.Select(e=> new ViewMaterial
			{
				Id = e.Id,
				LineId = e.Line.LineNumber,
				SheetId = e.Sheet.SheetNumber,
				Discipline = e.Discipline,
				Quantity = e.Quantity,
				MaterialDescriptionId = e.MaterialDescriptions.ItemCode,
				SubmitDateTime = e.SubmitDateTime,
				UserId = e.User.FullName
			});
	}
