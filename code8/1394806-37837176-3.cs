	var query = 
		new[] {
		new { A = 3, B = 3 },
		new { A = 2, B = 2 },
		new { A = 2, B = 2 },
		new { A = 1, B = 1 }
	}
	.OrderBy(x => x.A)
	.ThenBy(x => x.B)
    .ThrowIfConsecutiveItemsAreEqual()
	.ToList();
