    cols.Add(grid.Column(c, c, 
        item => 
        { 
            HtmlString h = new HtmlString("<span id=\"" + c + "\">" + item[c] + "</span>"); 
			return h; 
		},
		"", true));
