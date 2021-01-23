    var publishedFinal = sampleInput
    	.Publish(_si => _si
    		.Where(c => char.IsLetter(c))
    		.Buffer(bufferBoundaries)
    		.Where(l => l.Any())
    		.Select(lc => new string(lc.ToArray()))
    		.Merge( _si
    			.Where(c => char.IsNumber(c))
    			.Select(c => c.ToString())
    		)
    	);
