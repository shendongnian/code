    vs.Setters.Add(new Setter
        {
    	Target = new TargetPropertyPath
    		{
    			Path = new PropertyPath("(Image.Visibility)"),
    			Target = *yourimage*
    		},
    	Value = Visibility.Collapsed
    });
